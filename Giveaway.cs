using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace StreamGiveaway
{
    class Giveaway
    {
        public GiveawayWindow window;
        public TwitchRequest request;

        private Timer timer;            // Timer for cycling the usernames
        private Timer interval_timer;   // Timer for controlling the cycle speed
        private int timer_count;        // Keeps track of interval_timer

        private bool final_round;       // Active after 10 ticks of interval_timer
        private bool running;

        private int giveaway_index;     
        private int winner;             // An index of the giveaway list.

        private List<string> giveaway_list;

        public Giveaway(string client_id, string access_token)
        {
            this.window = new GiveawayWindow();
            this.window.BackColor = ColorTranslator.FromHtml("#493493");
            this.window.Size = new Size(1280, 720);

            this.request = new TwitchRequest(client_id, access_token);
            this.giveaway_list = new List<string>();
        }

        /*
         * timer will cycle through usernames once every 5s.
         * interval_timer, on every 1s tick, will slow down the above timer's interval
         * This makes the cycling gradually slow down.
         * Spacebar begins the cycling.
         */
        public void initialize()
        {
            this.window.changeNameLabel("");
            this.giveaway_index = 0;

            this.timer = new Timer();
            this.timer.Interval = 5;
            this.timer.Tick += new EventHandler(usernameTimerChange);

            this.interval_timer = new Timer();
            this.interval_timer.Interval = 1000;
            this.interval_timer.Tick += new EventHandler(intervalTimerChange);

            Random rand = new Random();
            this.winner = rand.Next(0, giveaway_list.Count);
            this.running = false;

            this.window.KeyDown += beginTimers;

            this.window.Show();
        }

        public void addCustom(List<string> users)
        {
            foreach(string user in users)
            {
                if (!this.giveaway_list.Contains(user))
                {
                    this.giveaway_list.Add(user);
                }
            }
        }

        public void addSubscribers(string username, List<string> blacklist)
        {
            List<string> subs = request.getSubscribers(username, blacklist);
            this.addCustom(subs);
        }

        public void addChat(string username, List<string> blacklist, bool ignore_mods)
        {
            List<string> users = request.getChatUsers(username, blacklist);
            this.addCustom(users);

            if (!ignore_mods)
            {
                List<string> mods = request.getChatMods(username, blacklist);
                this.addCustom(mods);
            }
        }

        public void addFollowers(string username, List<string> blacklist)
        {
            List<string> followers = request.getFollowers(username, blacklist);
            this.addCustom(followers);
        }

        private void beginTimers(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && this.running == false)
            {
                this.running = true;
                this.timer.Start();
                this.interval_timer.Start();
            }
        }

        private void intervalTimerChange(object sender, EventArgs e)
        {
            timer.Interval = timer.Interval + 20;
            this.timer_count++;
            
            if (this.timer_count == 10)
            {
                this.interval_timer.Stop();
                this.final_round = true;
            }        
        }

        private void usernameTimerChange(object sender, EventArgs e)
        {
            this.window.changeNameLabel(this.giveaway_list[giveaway_index]);

            // Resets all the values to allow for re-rolling
            if (final_round && this.giveaway_index == this.winner)
            {
                timer.Stop();
                this.running = false;
                this.final_round = false;
                this.giveaway_index = 0;
                this.timer.Interval = 5;
                Random rand = new Random();
                this.winner = rand.Next(0, giveaway_list.Count);
                this.timer_count = 0;
                return;
            }

            if (final_round)
                this.giveaway_index = this.winner;
            else
                this.giveaway_index = (this.giveaway_index + 1) % this.giveaway_list.Count;
        }
    }
}
