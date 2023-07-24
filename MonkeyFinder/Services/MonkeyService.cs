using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    //Here we will implement getting monkeys from the internet
    HttpClient httpClient;
    public MonkeyService()
    {
        httpClient = new HttpClient();    
    }

    

    List<Monkey> monkeyList = new List<Monkey>();
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        // If the List is 0, call to get Monkeys from the Internet

        var url = "https://www.montemagno.com/monkeys.json";
        var response = await httpClient.GetAsync(url);

        //Check if we get results back? 
        if (response.IsSuccessStatusCode)
        {
            //Get the monkeys list
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }
        return monkeyList;
    }
}
