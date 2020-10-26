using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CommonSRC.Dtos;
using System.Text.Json;
using AutoMapper;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorApp1.Models;



namespace BlazorApp1.Data
{
    public class EmployeeDataService2
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public EmployeeDataService2(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;

        }

        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel empView)
        {
            var emp = _mapper.Map<EmployeeCreateDto>(empView);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new System.Net.Http.StringContent
                (
                    JsonSerializer.Serialize<EmployeeCreateDto>(emp),
                    System.Text.Encoding.UTF8,
                    "application/json"
                ),

            };
            var client = _httpClientFactory.CreateClient("employees");
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            //var resp = await client.GetAsync("https://localhost:5001/api/employees");
            //emplo = await resp.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var obj = await response.Content.ReadFromJsonAsync<EmployeeReadDto>();
                return _mapper.Map<EmployeeViewModel>(obj);
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeViewModel> DeleteEmployee(EmployeeViewModel empView)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{empView.id}");
            var client = _httpClientFactory.CreateClient("employees");
            var response = await client.SendAsync(request);
            //var resp = await client.GetAsync("https://localhost:5001/api/employees");
            //emplo = await resp.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return empView;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var client = _httpClientFactory.CreateClient("employees");
            var response = await client.SendAsync(request);
            //var resp = await client.GetAsync("https://localhost:5001/api/employees");
            //emplo = await resp.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength > 0)
                {
                    var empArray = await response.Content.ReadFromJsonAsync<EmployeeReadDto[]>();
                    return _mapper.Map<EmployeeViewModel[]>(empArray).AsEnumerable<EmployeeViewModel>();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeViewModel> GetEmployee(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{id}");
            var client = _httpClientFactory.CreateClient("employees");
            var response = await client.SendAsync(request);
            //var resp = await client.GetAsync("https://localhost:5001/api/employees");
            //emplo = await resp.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var emp = await response.Content.ReadFromJsonAsync<EmployeeReadDto>();
                return _mapper.Map<EmployeeViewModel>(emp);
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel empView)
        {
            var emp = _mapper.Map<EmployeeUpdateDto>(empView);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri =new Uri( $"https://localhost:5001/api/employees/{empView.id}" ),
                Content = new System.Net.Http.StringContent
                (
                    JsonSerializer.Serialize<EmployeeUpdateDto>(emp),
                    System.Text.Encoding.UTF8,
                    "application/json"
                ),

            };

            var client = _httpClientFactory.CreateClient("employees");
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            //var resp = await client.GetAsync("https://localhost:5001/api/employees");
            //emplo = await resp.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return empView;
            }
            else
            {
                return null;
            }
        }

    }
}
