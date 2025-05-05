using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarViewHolder
{
    public CarView CurrentView
    {
        get => currentView;
        private set
        {
            currentView?.Hide();
            currentView = value;
            currentView.Show();
        }
    }
    
    private List<CarView> views = new List<CarView>();
    private CarView currentView;
    private Transform viewsParent;
    
    private CarViewHolder(CarMonos carMonos)
    {
        viewsParent = carMonos.viewHolderTransform;
    }

    public void SetCarView(CarView carView)
    {
        var view = views.Find(i => i.CarType == carView.CarType);

        if (view == null)
        {
            view = AddNewView(carView);
        }
        
        CurrentView = view;
    }

    private CarView AddNewView(CarView carView)
    {
        var instance = Object.Instantiate(carView, viewsParent);
        views.Add(instance);
        return instance;
    }
}