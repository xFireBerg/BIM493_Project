﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BIM493_Project.ViewModels.Forms
{
    public class CompetitionPageViewModel : ContentPage
    {
        public CompetitionPageViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}