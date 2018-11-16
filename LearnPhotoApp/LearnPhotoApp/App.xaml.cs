using System;
using System.Threading.Tasks;
using LearnPhotoApp.Managers;
using LearnPhotoApp.ViewModels;
using LearnPhotoApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LearnPhotoApp
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage, NavigationPageViewModel>("Navigation");

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>("Main");
            containerRegistry.RegisterForNavigation<StoredPhotos, StoredPhotosViewModel>("MyPhotos");
            containerRegistry.Register<IPhotoManagerApi, PhotoManagerApi>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await InitAsync();
        }

        private async Task InitAsync()
        {
            await NavigationService.NavigateAsync("Main");
        }
    }
}
