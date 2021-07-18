open System
open System.Net.Http
open TripPin
open TripPin.Types

let baseUri = Uri "https://services.odata.org/V4/(S(s3lb035ptje4a1j0bvkmqqa0))/TripPinServiceRW"
let httpClient = new HttpClient(BaseAddress=baseUri)
let tripPinService = TripPinClient(httpClient)
let airlinesResponse = tripPinService.AirlinesAirlineListAirline(top=100)

match airlinesResponse with
| AirlinesAirlineListAirline.OK data ->
    let airlines = defaultArg data.value []
    for airline in airlines do
        printfn $"{airline.AirlineCode} => {airline.Name}"

| AirlinesAirlineListAirline.DefaultResponse error ->
    printfn "%A" error