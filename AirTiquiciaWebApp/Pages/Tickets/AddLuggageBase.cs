using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Tickets
{
    public class AddLuggageBase : ComponentBase
    {
        [Inject]
        public ILuggageService LuggageService { get; set; }
        public Luggage Luggage { get; set; } = new Luggage();
        public Luggage Luggage2 { get; set; } = new Luggage();
        public Luggage Luggage3 { get; set; } = new Luggage();

        public bool luggage2, luggage3, max;


        [Inject]
        public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        public int count;
        int weight = 10, weight2, weight3, Seats, Quantity = 1;
        decimal cost = 0;

        [Inject ]
        public IModalService modal { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Luggage.Weight = 1;
            Luggage.Cost = 20;

            Seats = await localStorage.GetItemAsync<Int32>("Seats");
        }

        protected void changeWeight(ChangeEventArgs args)
        {
            switch (args.Value)
            {
                case "1":
                    Luggage.Cost = 20;
                    weight = 10;
                    break;
                case "2":
                    Luggage.Cost = 30;
                    weight = 23;
                    break;
                case "3":
                    Luggage.Cost = 40;
                    weight = 32;
                    break;
            }
        }
        protected void changeLuggage2Weight(ChangeEventArgs args)
        {
            switch (args.Value)
            {
                case "1":
                    Luggage2.Cost = 20;
                    weight2 = 10;
                    break;
                case "2":
                    Luggage2.Cost = 30;
                    weight2 = 23;
                    break;
                case "3":
                    Luggage2.Cost = 40;
                    weight2 = 32;
                    break;
            }
        }

        protected void changeLuggage3Weight(ChangeEventArgs args)
        {
            switch (args.Value)
            {
                case "1":
                    Luggage3.Cost = 20;
                    weight3 = 10;
                    break;
                case "2":
                    Luggage3.Cost = 30;
                    weight3 = 23;
                    break;
                case "3":
                    Luggage3.Cost = 40;
                    weight3 = 32;
                    break;
            }
        }

        protected void addLuggage()
        {
            count++;
            if (count == 1)
            {
                weight2 = 10;
                luggage2 = true;
                Luggage2.Cost = 20;
                Quantity = 2;
            }

            if (count == 2)
            {
                weight3 = 10;
                luggage3 = true;
                Luggage3.Cost = 20;
                Quantity = 3;
            }

            if (count > 2)
            {
                max = true;
            }
        }

        protected void hideLuggage2()
        {
            luggage2 = false;
            Luggage2.Cost = 0;
            weight2 = 0;
            Quantity = 1;
            count = 0;
        }

        protected void hideLuggage3()
        {
            luggage3 = false;
            Luggage3.Cost = 0;
            weight3 = 0;
            Quantity = 2;
            count = 1;
            max = false;
        }

        protected async Task sendLuggage()
        {
            await localStorage.SetItemAsync("LuggageQuantity", Quantity);

            weight = weight + weight2 + weight3;
            await localStorage.SetItemAsync("LuggageWeight", weight);

            cost = Luggage.Cost + Luggage2.Cost + Luggage3.Cost;
            await localStorage.SetItemAsync("LuggageCost", cost);

            NavigationManager.NavigateTo("/Usuarios/Datos/" + Seats);
        }
    }
}
