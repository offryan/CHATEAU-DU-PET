using ChateauDuPet.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChateauDuPet.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}