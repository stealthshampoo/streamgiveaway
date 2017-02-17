using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace StreamGiveaway
{
    /*
     * All user lists are returned and handled as List<string>.
     * All lists, including blacklists, use "display_name", and so are case sensitive.
     */
    class TwitchRequest
    {
        private string channelurl = "https://api.twitch.tv/kraken/channels";
        private string tmiurl = "https://tmi.twitch.tv";

        private string client_id;
        private string access_token;

        public TwitchRequest(string client_id, string access_token)
        {
            this.client_id = client_id;
            this.access_token = access_token;
        }

        /*
         * Generic request function.
         * Returns a JSON string of the response for parsing.
         * Rethrows any web exceptions.
         */
        private string request(string url)
        {
            string json_raw = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    json_raw = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                Console.WriteLine(errorResponse);
                throw;
            }

            return json_raw;
        }

        public string getDisplayName(string username)
        {
            string url = string.Format("{0}/{1}?client_id={2}", channelurl, username, client_id);
            string json = this.request(url);

            JObject user = JObject.Parse(json);
            return (string)user["display_name"];
        }

        /*
         * Should be a loop like getFollowers. Will be added later.
         * Original implementation was for a streamer with under 100 subscribers.
         */
        public List<string> getSubscribers(string username, List<string> blacklist)
        {
            string url = string.Format("{0}/{1}/subscriptions?client_id={2}&limit=100&oauth_token={3}",
                channelurl, username.ToLower(), client_id, access_token);
            List<string> sub_list = new List<string>();
            string json_raw = this.request(url);

            JObject subs = JObject.Parse(json_raw);

            foreach (JObject sub in subs["subscriptions"])
            {
                if (!blacklist.Contains((string)sub["user"]["name"]))
                {
                    sub_list.Add((string)sub["user"]["display_name"]);
                }
            }

            return sub_list;
        }

        // These commands use an undocumented API. It's easy to understand.
        public List<string> getChatMods(string username, List<string> blacklist)
        {
            string url = string.Format("{0}/group/user/{1}/chatters", tmiurl, username);
            List<string> mods = new List<string>();

            string json = this.request(url);

            JObject chat = JObject.Parse(json);
            foreach (string mod in chat["chatters"]["moderators"])
            {
                if (!blacklist.Contains(mod))
                {
                    mods.Add(this.getDisplayName(mod));
                }
            }

            return mods;
        }

        // This does NOT include mods. 
        public List<string> getChatUsers(string username, List<string> blacklist)
        {
            string url = string.Format("{0}/group/user/{1}/chatters", tmiurl, username);
            List<string> users = new List<string>();

            string json = this.request(url);

            JObject chat = JObject.Parse(json);
            foreach (string user in chat["chatters"]["viewers"])
            {
                if (!blacklist.Contains(user))
                {
                    users.Add(this.getDisplayName(user));
                }
            }

            return users;
        }

        /*
         * Returns the list of followers of the streamer.
         * Gets 100 followers per API call, and loops until all followers are collected.
         * This can take a VERY long time as a result.
         */
        public List<string> getFollowers(string username, List<string> blacklist)
        {
            List<string> followers = new List<string>();

            string base_url = string.Format("{0}/{1}/follows?client_id={2}&limit=100&oauth_token={3}",
                channelurl, username, client_id, access_token);
            string json;

            string cursor = "";

            do
            {
                string url;
                if (cursor.Equals(""))
                    url = base_url;
                else
                    url = string.Format("{0}&cursor={1}", base_url, cursor.ToString());

                json = this.request(url);

                JObject follows = JObject.Parse(json);
                foreach (JObject follow in follows["follows"])
                {
                    if (!blacklist.Contains((string)follow["user"]["name"]))
                    {
                        followers.Add((string)follow["user"]["display_name"]);
                    }
                }

                cursor = (string)follows["_cursor"];
            } while (cursor != null);

            return followers;
        }
    }
}
