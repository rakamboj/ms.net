using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Registration.Web.BAL
{
    class CostBAL
    {
        double cost;
        public double CalculateRoomCost()
        {
            try
            {
                double difference, individualCost;
                if (cost < 200)
                    difference = 1.20;
                else if (cost >= 200 && cost < 400)
                    difference = 1.50;
                else if (cost >= 400 && cost < 600)
                    difference = 1.80;
                else
                    difference = 2.00;
                individualCost = cost * difference;
                if (individualCost > 300)
                    cost = individualCost * 15 / 100.0;
                cost = individualCost + cost;
            }
            catch (Exception)
            {

            }
            return cost;
        }
    }
}
