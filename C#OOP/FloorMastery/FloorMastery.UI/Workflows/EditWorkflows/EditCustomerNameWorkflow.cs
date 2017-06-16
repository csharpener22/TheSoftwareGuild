﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.BLL;
using FloorMastery.BLL.Factories;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Workflows.EditWorkflows
{
    public class EditCustomerNameWorkflow
    {
        public void EditCustomerName(Order order)
        {
            OrderManager orderMan = OrderManagerFactory.Create();

            order.CustomersName = ConsoleIO.EditCustomerName();

            orderMan.AddOrder(order);
            ConsoleIO.DisplaySingleOrderDetails(order);
            Console.ReadKey();
            Console.Clear();


        }
    }
}