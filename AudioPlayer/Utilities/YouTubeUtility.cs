using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using VideoLibrary;
using Video = Google.Apis.YouTube.v3.Data.Video;

namespace AudioPlayer
{
    static class YouTubeUtility
    {
        public const string YouTubeBaseUrl = "https://www.youtube.com/watch?v=";

        private const string api_key = "AIzaSyDaQVdgZdhza5J4--FrTdXzqnlKV5jkAIM";
        private static YouTubeService _youTubeService;

        public static async Task<List<Audio>> GetAudioListFromQueryAsync(string query)
        {
            SearchListResponse searchListResponse;
            try
            {
                searchListResponse = await GetSearchListResponseAsync(query);
            }catch(HttpRequestException)
            {
                throw;
            }

            List<Audio> audioList = new List<Audio>();
            foreach (SearchResult searchResult in searchListResponse.Items)
            {
                bool isNotLiveStreamVideo = searchResult.Snippet.LiveBroadcastContent.Equals("none");
                bool isAYouTubeVideo = searchResult.Id.Kind.Equals("youtube#video");
                if (isAYouTubeVideo && isNotLiveStreamVideo)
                {
                    Audio audio = new Audio();
                    audio.Title = searchResult.Snippet.Title;
                    audio.Artists.Add(searchResult.Snippet.ChannelTitle);
                    audio.Source = AudioSource.Youtube;
                    audio.YoutubeVideoId = searchResult.Id.VideoId;
                    Thumbnail highestResThumbnail = GetHighestResThumbnail(searchResult.Snippet.Thumbnails);
                    if (highestResThumbnail == null)
                    {
                        audio.Thumbnail = null;
                    }else
                    {
                        audio.Thumbnail = await GetThumbnailImage(highestResThumbnail.Url);
                    }

                    try
                    {
                        audio.SourceUrl = await GetYouTubeVideoUrlAsync(searchResult.Id.VideoId);
                    }
                    catch (HttpRequestException)
                    {
                        throw;
                    }
                    catch(Exception)
                    {
                        continue;
                    }
                    audioList.Add(audio);
                }
            }
            return audioList;
        }
        public static async Task<List<Audio>> GetAudioListAsync(List<string> videoIds)
        {
            List<Audio> audioList = new List<Audio>();
            foreach (string videoId in videoIds)
            {
                Audio audio = null;
                try
                {
                    audio = await GetAudioObjectAsync(videoId);
                }
                catch (HttpRequestException)
                {
                    throw;
                }
                catch (Exception)
                {
                    continue;
                }
                audioList.Add(audio);
            }
            return audioList;
        }
        public static async Task<Audio> GetAudioObjectFromUrl(string youtubeUrl)
        {
            string videoId = GetVideoId(youtubeUrl);
            return await GetAudioObjectAsync(videoId);
        }

        private static async Task<Audio> GetAudioObjectAsync(string videoId)
        {
            Audio audio = new Audio();
            Video video = null;
            try
            {

                video = await GetYoutubeVideoAsync(videoId);
                string youtubeVideoUrl = await GetYouTubeVideoUrlAsync(videoId);
                audio.SourceUrl = youtubeVideoUrl;
            }
            catch (Exception)
            {
                // HttpRequestException, ArgumentOutOfRangeException, 
                // InvalidOperationException
                throw;
            }

            audio.Title = video.Snippet.Title;
            audio.Artists.Add(video.Snippet.ChannelTitle);
            audio.YoutubeVideoId = videoId;
            audio.Source = AudioSource.Youtube;
            Thumbnail thumbnail = GetHighestResThumbnail(video.Snippet.Thumbnails);
            if (thumbnail == null)
            {
                audio.Thumbnail = null;
            }
            else
            {
                audio.Thumbnail = await GetThumbnailImage(thumbnail.Url);
            }
            return audio;
        }

        public static async Task<List<Audio>> GetAudioListFromYoutubeUrlsAsync(List<string> youtubeUrls)
        {
            List<string> videoIds = GetVideoIdsFromYoutubeUrls(youtubeUrls);
            try
            {
                List<Audio> audioList = await GetAudioListAsync(videoIds);
                return audioList;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        #region Thumbnail Image Gathering
        private static async Task<Image> GetThumbnailImage(string thumbnailUrl)
        {
            var wb = new WebClient();
            if (thumbnailUrl == null) { return null; }
            byte[] bin = await wb.DownloadDataTaskAsync(thumbnailUrl);
            Image img = Image.FromStream(new MemoryStream(bin));
            return img;
        }
        private static Thumbnail GetHighestResThumbnail(ThumbnailDetails thumbnails)
        {
            if (thumbnails.Maxres != null)
            {
                return thumbnails.Maxres;
            }
            if (thumbnails.High != null)
            {
                return thumbnails.High;
            }
            if (thumbnails.Medium != null)
            {
                return thumbnails.Medium;
            }
            if (thumbnails.Standard != null)
            {
                return thumbnails.Standard;
            }
            return thumbnails.Default__;
        }
        #endregion Thumbnail Image Gathering

        #region LibVideo Communication
        private static async Task<String> GetYouTubeVideoUrlAsync(string videoId)
        {
            string youtubeVideoUrl = YouTubeBaseUrl + videoId;
            var youTube = YouTube.Default; // starting point for YouTube actions
            YouTubeVideo ytvideo;
            try
            {
                ytvideo = await youTube.GetVideoAsync(youtubeVideoUrl); // gets a YouTubeVideo object with info about a video by its url
                return ytvideo.Uri;
            }
            catch (Exception)
            {   //InvalidOperationException or HttpRequestException
                throw;
            }
        }
        #endregion LibVideo Communication

        #region YouTube Data API Communication
        private static async Task<Video> GetYoutubeVideoAsync(string videoId)
        {
            if (_youTubeService == null)
            {
                _youTubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = api_key,
                    ApplicationName = typeof(YouTubeUtility).ToString()
                });
            }
            VideosResource.ListRequest videoListRequest = _youTubeService.Videos.List("snippet");
            videoListRequest.Id = videoId;
            videoListRequest.MaxResults = 1;
            try
            {
                VideoListResponse videoListResponse = await videoListRequest.ExecuteAsync();
                Video video = videoListResponse.Items[0];
                return video;
            }
            catch (Exception)
            {
                //HttpRequestException or ArgumentOutOfRangeException
                throw;
            }
        }
        private static async Task<SearchListResponse> GetSearchListResponseAsync(string query)
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = api_key,
                ApplicationName = typeof(YouTubeUtility).ToString()
            });
            // Call the search.list method to retrieve results matching the specified query term.
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.MaxResults = 5;

            try
            {
                SearchListResponse searchListResponse = await searchListRequest.ExecuteAsync();
                return searchListResponse;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        #endregion YouTube Data API Communication

        #region youtubeUrls to videoIds
        private static string GetVideoId(string youtubeUrl)
        {
            if (youtubeUrl == null) { return null; }

            var regex = @"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)";

            var match = Regex.Match(youtubeUrl, regex);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "";
        }

        private static List<string> GetVideoIdsFromYoutubeUrls(List<string> youtubeUrls)
        {
            if (youtubeUrls == null) { return null; }

            List<string> videoIds = new List<string>();
            foreach (string youtubeUrl in youtubeUrls)
            {
                string videoId = GetVideoId(youtubeUrl);
                videoIds.Add(videoId);
            }
            return videoIds;
        }
        #endregion youtubeUrls to videoIds
    }
}