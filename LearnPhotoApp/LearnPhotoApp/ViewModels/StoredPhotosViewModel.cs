using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnPhotoApp.Managers;
using LearnPhotoApp.Models;
using Prism.Navigation;

namespace LearnPhotoApp.ViewModels
{
    public class StoredPhotosViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly Photo _photo;
        private readonly IPhotoManagerApi _photoManagerApi;

        public StoredPhotosViewModel(INavigationService navigationService, Photo photo, IPhotoManagerApi photoManagerApi) : base(navigationService)
        {
            _navigationService = navigationService;
            _photo = photo;
            _photoManagerApi = photoManagerApi;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await Initialize();
        }

        private async Task Initialize()
        {
            var photos = await _photoManagerApi.GetMyPhotos();
            if (photos != null)
            {
                PhotosViewModels = new List<StoredPhotosViewModel>(photos.Select(c =>
                    new StoredPhotosViewModel(_navigationService, c, _photoManagerApi)));
            }
        }

        private List<StoredPhotosViewModel> _photosViewModels;
        public List<StoredPhotosViewModel> PhotosViewModels
        {
            get => _photosViewModels;
            set { _photosViewModels = value; RaisePropertyChanged(); }
        }

        public string PhotoName => _photo.PhotoName;
    }
}
