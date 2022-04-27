using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpress.Maui.Editors;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ChipsExample {
    public partial class MainPage : ContentPage {
        const int animationDuration = 600;

        ViewModel VM { get; }

        public MainPage() {
            InitializeComponent();
            BindingContext = VM = new ViewModel();
            colorChoiceChipGroup.SelectionChanged += OnColorChanged;
        }

        async void OnColorChanged(object sender, EventArgs e) {
            superhero.TranslationX = 0;
            superhero.CancelAnimations();
            double translationX = superhero.Width;
            await Task.WhenAll(
                superhero.FadeTo(0, animationDuration, Easing.Linear),
                superhero.TranslateTo(translationX, superhero.Y, animationDuration, Easing.CubicInOut)
                );

            VM.UpdateSuperhero();
            superhero.TranslationX = -translationX;

            await Task.WhenAll(
                superhero.FadeTo(1, animationDuration, Easing.Linear),
                superhero.TranslateTo(0, superhero.Y, animationDuration, Easing.CubicInOut)
                );
        }
    }
}

