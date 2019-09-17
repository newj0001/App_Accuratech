using Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UI_Mobile.Behaviors
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        private readonly SubItemEntityModel _subItemEntityModel = new SubItemEntityModel();
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            int result;

            bool isValid = int.TryParse(e.NewTextValue, out result);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

    }
}
