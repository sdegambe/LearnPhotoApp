using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using Prism.Navigation;

namespace LearnPhotoApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        public virtual void Destroy()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}
