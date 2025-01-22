using System;
using ReactiveUI;

namespace EmUI.ViewModels;

public class ViewModelBase
    : ReactiveObject
{
    public ViewModelBase? InnerViewModel { get; set; }
    
    protected void NavigateTo<TSecondaryViewModel>(params object[] parameters)
        where TSecondaryViewModel : ViewModelBase =>
        InnerViewModel = (TSecondaryViewModel)(parameters.Length > 0 ? 
            Activator.CreateInstance(typeof(TSecondaryViewModel), parameters)
            : Activator.CreateInstance(typeof(TSecondaryViewModel)))!;
}