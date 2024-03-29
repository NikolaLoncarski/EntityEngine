﻿using Azure.Core;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.Text.Json.Nodes;
using CodeFirstApi.PartTwo.Model;
using System.Reflection.PortableExecutable;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using CodeFirstApi.PartTwo.Service.ExternalAPI.Model;
using System.Reflection.Metadata.Ecma335;


namespace CodeFirstApi.PartTwo.Service.ExternalAPI
{


    public class CarAPI
    {

		public async Task<List<string>> CarAPICall(int year, string make)
		{

            string url = $"https://car-api2.p.rapidapi.com/api/models?make={make}&sort=id&direction=asc&year={year}&verbose=yes";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
    {
        { "X-RapidAPI-Key", "53deb9881amshaa9f0b81993aa50p173d49jsn92c2a6088374" },
        { "X-RapidAPI-Host", "car-api2.p.rapidapi.com" },
    },
            };
       List<string> models = new List<string>();

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var root = JsonSerializer.Deserialize<RootObject>(body);

                for (int i = 0; i < root.data.Count; i++) {
                    models.Add(root.data[i].name); }
                
                }


           return models;

            }
            
             
       
        }


      

        
    }

