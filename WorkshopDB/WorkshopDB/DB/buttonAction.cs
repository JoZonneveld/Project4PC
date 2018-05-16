using System;
using Android.Widget;

namespace WorkshopDB.DB
{
    public class buttonAction
    {
        private Button button;
        private Action action;

        public buttonAction(Button button, Action action)
        {
            this.button = button;
            this.action = action;
        }

        public void execute()
        {
            this.button.Click += delegate { this.action(); };
        }
    }
}