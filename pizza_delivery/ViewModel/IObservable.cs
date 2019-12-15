﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza_delivery.ViewModel
{
    public interface IObservable
    {
        void AddBasket(IObserver o);
        void NotifyObservers();
    }
    
        

    
}
