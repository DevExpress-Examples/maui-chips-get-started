using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace ChipsExample {
    public class ViewModel : INotifyPropertyChanged {
        string selectedSize;
        string selectedSuperhero;

        public IList<string> Sizes { get; }
        public IList<string> Superheroes { get; }
        public int SelectedColorIndex { get; set; }

        public string SelectedSize {
            get => this.selectedSize;
            set {
                this.selectedSize = value;
                OnPropertyChanged();
            }
        }
        public string SelectedSuperhero {
            get => this.selectedSuperhero;
            set {
                this.selectedSuperhero = value;
                OnPropertyChanged();
            }
        }

        public ViewModel() {
            Sizes = new List<string>() { "S", "M", "L", "XL", "XXL", "XXXL" };
            Superheroes = new List<string>() {
                "superhero_red",
                "superhero_orange",
                "superhero_yellow",
                "superhero_green",
                "superhero_blue",
                "superhero_purple"
            };
            SelectedColorIndex = 1;
            SelectedSize = Sizes[2];
            UpdateSuperhero();
        }

        public void UpdateSuperhero() {
            SelectedSuperhero = (SelectedColorIndex == -1) ? null : Superheroes[SelectedColorIndex];
        }

        void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}

