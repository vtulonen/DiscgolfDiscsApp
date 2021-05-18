using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscgolfLib.Models;

namespace DiscgolfLib
{
    public class DiscProcessor
    {
        public static async Task<ObservableCollection<DiscModel>> LoadAllDiscs()
        {
            string url = $"{ApiHelper.ApiClient.BaseAddress}/discs";

            // Using statement disposes everything done within the curly brackets after completion
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ObservableCollection<DiscModel> allDiscs = await response.Content.ReadAsAsync<ObservableCollection<DiscModel>>();

                    return allDiscs;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
