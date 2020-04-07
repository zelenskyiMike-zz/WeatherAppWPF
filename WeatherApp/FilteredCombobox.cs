using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections;
using System.Windows.Data;
using System.Windows.Input;

namespace WeatherApp
{
    public class FilteredCombobox : ComboBox
    {
        public static readonly DependencyProperty MinimumSearchLengthProperty = DependencyProperty.Register("MinimumSearchLength", typeof(int),
                typeof(FilteredCombobox),
                new UIPropertyMetadata(3));

        private string oldFilter = string.Empty;
        private string currentFilter = string.Empty;

        public FilteredCombobox()
        {
        }

        [DefaultValue(3)]
        public int MinimumSearchLength
        {
            get
            {
                return (int)this.GetValue(MinimumSearchLengthProperty);
            }

            set
            {
                this.SetValue(MinimumSearchLengthProperty, value);
            }
        }

        protected TextBox EditableTextbox
        {
            get { return this.GetTemplateChild("PART_EditableTextbox") as TextBox; }
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            if (newValue != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
                view.Filter += this.FilterPredicate;
            }
            if (oldValue != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);
                view.Filter += this.FilterPredicate;
            }

            base.OnItemsSourceChanged(oldValue, newValue);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                this.IsDropDownOpen = false;
            }
            else if (e.Key == Key.Escape)
            {
                this.IsDropDownOpen = false;
                this.SelectedIndex = -1;
                this.Text = this.currentFilter;
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    this.IsDropDownOpen = true;
                }
                base.OnPreviewKeyDown(e);
            }
            this.oldFilter = this.Text;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                // Navigation keys are ignored
            }
            else if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                this.ClearFilter();
            }
            else
            {
                if (this.Text != this.oldFilter)
                {
                    if (this.Text.Length == 0 || this.Text.Length >= this.MinimumSearchLength)
                    {
                        this.RefreshFilter();
                        this.IsDropDownOpen = true;

                        // Unselect
                        this.EditableTextbox.SelectionStart = int.MaxValue;
                    }
                }

                base.OnKeyUp(e);

                this.currentFilter = this.Text;
            }
        }

        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            this.ClearFilter();
            int temp = this.SelectedIndex;
            this.SelectedIndex = -1;
            this.Text = string.Empty;
            this.SelectedIndex = temp;
            base.OnPreviewLostKeyboardFocus(e);
        }

        private void RefreshFilter()
        {
            if (this.ItemsSource != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);
                view.Refresh();
            }
        }

        private void ClearFilter()
        {
            this.currentFilter = string.Empty;
            this.RefreshFilter();
        }

        private bool FilterPredicate(object value)
        {
            // No filter, no text
            if (value == null)
            {
                return false;
            }

            // No text, no filter
            if (this.Text.Length == 0)
            {
                return true;
            }

            // Case insensitive search
            return value.ToString().ToLower().Contains(this.Text.ToLower());
        }
    }
}
