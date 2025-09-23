using ConsoleApp1.Intermidiate_Crouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Advance_Crouse
{
    public class OrderEventArgs : EventArgs
    {
        public int OrderID { get;  }
        public string OrderName { get;  }
        public OrderEventArgs(int orderID, string orderName)
        {
            OrderID = orderID;
            OrderName = orderName;
        }
    }
    public class OrderProcessor
    {
        public event EventHandler<OrderEventArgs> OrderProcessed;
        public void ProcessOrder(int id,string customername)
        {
            Console.WriteLine($"[Processor] Processing order #{id} for {customername}");
            OnOrderProcessed(id, customername);
        }
        protected virtual void OnOrderProcessed(int id, string customername)
        {
            OrderProcessed?.Invoke(this, new OrderEventArgs(id, customername));
        }
    }
    public class EmailService
    {
        public void OnOrderProcessed(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"[EmailService] Sending confirmation email to {e.OrderName} for Order #{e.OrderID}");
        }
    }
    public class LogService
    {
        public void OnOrderProcessed(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"[LogService] Logging order #{e.OrderID} for customer {e.OrderName}");
        }
    }

    //// using interface :
    
    /// <summary>
    
    
     public class FireEventArgs : EventArgs
     {
    public string Location { get; }

    public FireEventArgs(string location)
    {
        Location = location;
    }
     }

    /// </summary>


    public interface IFireAlarm
    {
        event EventHandler<FireEventArgs> FireDetected;
        void DetectFire(string location);
    }

    
    public class InterfaceSmokeAlarm : IFireAlarm
    {
        public event EventHandler<FireEventArgs> FireDetected;

        public void DetectFire(string location)
        {
            Console.WriteLine($"🚭 Smoke detected at {location}!");
            FireDetected?.Invoke(this, new FireEventArgs(location));
        }
    }
    public class interfaceHeatAlarm : IFireAlarm
    {
        public event EventHandler<FireEventArgs> FireDetected;

        public void DetectFire(string location)
        {
            Console.WriteLine($"🔥 Heat alarm triggered at {location}!");
            FireDetected?.Invoke(this, new FireEventArgs(location));
        }
    }

    ///// using inheretence 


    public class BaseAlarm
    {
        public event EventHandler<FireEventArgs> BaseFireDetected;

        protected void OnFireDetected(string location)
        {
            BaseFireDetected?.Invoke(this, new FireEventArgs(location));
        }

        public virtual void DetectFire(string location)
        {
            Console.WriteLine($"[Base Alarm] Fire detected at {location}");
            OnFireDetected(location);
        }
    }

    public class SmokeAlarm : BaseAlarm
    {
        public override void DetectFire(string location)
        {
            Console.WriteLine($"🚭 Smoke detected! Raising alarm at {location}");
            base.DetectFire(location);
        }
    }

    public class HeatAlarm : BaseAlarm
    {
        public override void DetectFire(string location)
        {
            Console.WriteLine($"🔥 Heat levels critical at {location}");
            base.DetectFire(location);
        }
    }
    public class People
    {
        public void OnFireDetected(object sender, FireEventArgs e)
        {
            Console.WriteLine($"👨‍👩‍👧‍👦 People are evacuating from {e.Location}!");
        }
    }

    public class FireDepartment
    {
        public void OnFireDetected(object sender, FireEventArgs e)
        {
            Console.WriteLine($"🚒 Fire Department rushing to {e.Location}!");
        }
    }

}
