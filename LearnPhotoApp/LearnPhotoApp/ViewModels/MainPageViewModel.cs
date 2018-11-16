using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LearnPhotoApp.Managers;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Navigation;
using Xamarin.Forms;

namespace LearnPhotoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPhotoManagerApi _photoManagerApi;
      
        public MainPageViewModel(INavigationService navigationService, IPhotoManagerApi photoManagerApi) : base(navigationService)
        {
            _navigationService = navigationService;
            _photoManagerApi = photoManagerApi;
        }

        private ICommand _showMyPhotosCommand;
        public ICommand ShowMyPhotosCommand => _showMyPhotosCommand ?? (_showMyPhotosCommand = new Command(ShowMyPhotosClick));

        private async void ShowMyPhotosClick()
        {
            await _navigationService.NavigateAsync("MyPhotos");
        }

        private ICommand _takePhotoCommand;
        public ICommand TakePhotoCommand => _takePhotoCommand ?? (_takePhotoCommand = new Command(TakePhotoClick));

        private async void TakePhotoClick(object obj)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;
            if (await _photoManagerApi.PutPhotoToStorage(file.Path))
            {
                await _photoManagerApi.InsertPhoto(file.Path);
            }                      
        }
    }
}
