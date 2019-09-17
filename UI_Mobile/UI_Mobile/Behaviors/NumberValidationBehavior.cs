using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UI_Mobile.Behaviors
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            int result;

            bool isValid = int.TryParse(e.NewTextValue, out result);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
