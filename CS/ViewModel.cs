using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;

namespace ChipsExample {
    public class ViewModel : INotifyPropertyChanged {
        string selectedSize;
        string selectedSuperhero;
        Rect imageRect;
        Rect detailsRect;

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
        public Rect ImageRect {
            get => this.imageRect;
            set {
                this.imageRect = value;
                OnPropertyChanged();
            }
        }
        public Rect DetailsRect {
            get => this.detailsRect;
            set {
                this.detailsRect = value;
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
                "superhero_lightblue",
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

        public void UpdateLayout(bool isHorizontalOrientation) {
            if (isHorizontalOrientation) {
                ImageRect = new Rect(0, 0, 0.5, 1.0);
                DetailsRect = new Rect(1.0, 0.0, 0.5, 1.0);
            } else {
                ImageRect = new Rect(0, 0, 1.0, 0.5);
                DetailsRect = new Rect(0.0, 1.0, 1.0, 0.5);
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}

