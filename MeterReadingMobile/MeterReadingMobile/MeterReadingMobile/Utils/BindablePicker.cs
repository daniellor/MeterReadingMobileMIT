﻿using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace MeterReadingMobile
{/// <summary>
/// source from https://github.com/XAM-Consulting/FreshEssentials/blob/master/src/FreshEssentials/Controls/BindablePicker.cs
/// </summary>
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
            base.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(BindablePicker), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnSelectedItemChanged), null, null, null);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(BindablePicker), null, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnItemsSourceChanged), null, null, null);
        public static readonly BindableProperty DisplayPropertyProperty = BindableProperty.Create("DisplayProperty", typeof(string), typeof(BindablePicker), null, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnDisplayPropertyChanged), null, null, null);
        private bool disableEvents;

        public IList ItemsSource
        {
            get { return (IList)base.GetValue(BindablePicker.ItemsSourceProperty); }
            set { base.SetValue(BindablePicker.ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return base.GetValue(BindablePicker.SelectedItemProperty); }
            set
            {
                base.SetValue(BindablePicker.SelectedItemProperty, value);
                if (ItemsSource != null && SelectedItem != null)
                {
                    if (ItemsSource.Contains(SelectedItem))
                    {
                        SelectedIndex = ItemsSource.IndexOf(SelectedItem);
                    }
                    else
                    {
                        SelectedIndex = -1;
                    }
                }
            }
        }

        public string DisplayProperty
        {
            get { return (string)base.GetValue(BindablePicker.DisplayPropertyProperty); }
            set { base.SetValue(BindablePicker.DisplayPropertyProperty, value); }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (disableEvents) return;

            if (SelectedIndex == -1)
            {
                this.SelectedItem = null;
            }
            else
            {
                this.SelectedItem = ItemsSource[SelectedIndex];
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BindablePicker picker = (BindablePicker)bindable;
            picker.SelectedItem = newValue;
            if (picker.ItemsSource != null && picker.SelectedItem != null)
            {
                int count = 0;
                foreach (object obj in picker.ItemsSource)
                {
                    if (obj == picker.SelectedItem)
                    {
                        picker.SelectedIndex = count;
                        break;
                    }
                    count++;
                }
            }
        }

        private static void OnDisplayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BindablePicker picker = (BindablePicker)bindable;
            picker.DisplayProperty = (string)newValue;
            loadItemsAndSetSelected(bindable);

        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BindablePicker picker = (BindablePicker)bindable;

            picker.ItemsSource = (IList)newValue;

            loadItemsAndSetSelected(bindable);
        }

        static void loadItemsAndSetSelected(BindableObject bindable)
        {
            BindablePicker picker = (BindablePicker)bindable;
            if (picker.ItemsSource as IEnumerable != null)
            {
                picker.disableEvents = true;
                picker.SelectedIndex = -1;
                picker.Items.Clear();
                int count = 0;
                foreach (object obj in (IEnumerable)picker.ItemsSource)
                {
                    string value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop = obj.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));
                        if (prop != null)
                        {
                            value = prop.GetValue(obj).ToString();
                        }
                        else
                        {
                            value = obj.ToString();
                        }
                    }
                    else
                    {
                        value = obj.ToString();
                    }
                    picker.Items.Add(value);
                    if (picker.SelectedItem != null)
                    {
                        if (picker.SelectedItem == obj)
                        {
                            picker.SelectedIndex = count;
                        }
                    }
                    count++;
                }
                picker.disableEvents = false;
            }
        }
    }
}
