namespace rec TripPin

open System.Net
open System.Net.Http
open System.Text
open TripPin.Types
open TripPin.Http

///This OData service is located at http://localhost
type TripPinClient(httpClient: HttpClient) =
    ///<summary>
    ///Get entities from Airlines
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.AirlinesAirlineListAirline
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Airlines" requestParts

        if status = HttpStatusCode.OK then
            AirlinesAirlineListAirline.OK(Serializer.deserialize content)
        else
            AirlinesAirlineListAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Add new entity to Airlines
    ///</summary>
    member this.AirlinesAirlineCreateAirline(body: MicrosoftODataSampleServiceModelsTripPinAirline) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Airlines" requestParts

        if status = HttpStatusCode.Created then
            AirlinesAirlineCreateAirline.Created(Serializer.deserialize content)
        else
            AirlinesAirlineCreateAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entity from Airlines by key
    ///</summary>
    ///<param name="airlineCode">key: AirlineCode of Airline</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.AirlinesAirlineGetAirline(airlineCode: string, ?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("AirlineCode", airlineCode)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Airlines({AirlineCode})" requestParts

        if status = HttpStatusCode.OK then
            AirlinesAirlineGetAirline.OK(Serializer.deserialize content)
        else
            AirlinesAirlineGetAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update entity in Airlines
    ///</summary>
    ///<param name="airlineCode">key: AirlineCode of Airline</param>
    ///<param name="body"></param>
    member this.AirlinesAirlineUpdateAirline
        (
            airlineCode: string,
            body: MicrosoftODataSampleServiceModelsTripPinAirline
        ) =
        let requestParts =
            [ RequestPart.path ("AirlineCode", airlineCode)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Airlines({AirlineCode})" requestParts

        if status = HttpStatusCode.NoContent then
            AirlinesAirlineUpdateAirline.NoContent
        else
            AirlinesAirlineUpdateAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete entity from Airlines
    ///</summary>
    ///<param name="airlineCode">key: AirlineCode of Airline</param>
    ///<param name="ifMatch">ETag</param>
    member this.AirlinesAirlineDeleteAirline(airlineCode: string, ?ifMatch: string) =
        let requestParts =
            [ RequestPart.path ("AirlineCode", airlineCode)
              if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/Airlines({AirlineCode})" requestParts

        if status = HttpStatusCode.NoContent then
            AirlinesAirlineDeleteAirline.NoContent
        else
            AirlinesAirlineDeleteAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entities from Airports
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.AirportsAirportListAirport
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Airports" requestParts

        if status = HttpStatusCode.OK then
            AirportsAirportListAirport.OK(Serializer.deserialize content)
        else
            AirportsAirportListAirport.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entity from Airports by key
    ///</summary>
    ///<param name="icaoCode">key: IcaoCode of Airport</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.AirportsAirportGetAirport(icaoCode: string, ?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("IcaoCode", icaoCode)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Airports({IcaoCode})" requestParts

        if status = HttpStatusCode.OK then
            AirportsAirportGetAirport.OK(Serializer.deserialize content)
        else
            AirportsAirportGetAirport.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update entity in Airports
    ///</summary>
    ///<param name="icaoCode">key: IcaoCode of Airport</param>
    ///<param name="body"></param>
    member this.AirportsAirportUpdateAirport(icaoCode: string, body: MicrosoftODataSampleServiceModelsTripPinAirport) =
        let requestParts =
            [ RequestPart.path ("IcaoCode", icaoCode)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Airports({IcaoCode})" requestParts

        if status = HttpStatusCode.NoContent then
            AirportsAirportUpdateAirport.NoContent
        else
            AirportsAirportUpdateAirport.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke functionImport GetNearestAirport
    ///</summary>
    member this.FunctionImportGetNearestAirport(lat: string, lon: string) =
        let requestParts =
            [ RequestPart.path ("lat", lat)
              RequestPart.path ("lon", lon) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/GetNearestAirport(lat={lat},lon={lon})" requestParts

        if status = HttpStatusCode.OK then
            FunctionImportGetNearestAirport.OK(Serializer.deserialize content)
        else
            FunctionImportGetNearestAirport.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Me
    ///</summary>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MePersonGetPerson(?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me" requestParts

        if status = HttpStatusCode.OK then
            MePersonGetPerson.OK(Serializer.deserialize content)
        else
            MePersonGetPerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update Me
    ///</summary>
    member this.MePersonUpdatePerson(body: MicrosoftODataSampleServiceModelsTripPinPerson) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Me" requestParts

        if status = HttpStatusCode.NoContent then
            MePersonUpdatePerson.NoContent
        else
            MePersonUpdatePerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Friends from Me
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeListFriends
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Friends" requestParts

        if status = HttpStatusCode.OK then
            MeListFriends.OK(Serializer.deserialize content)
        else
            MeListFriends.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get ref of Friends from Me
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    member this.MeListRefFriends
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Friends/$ref" requestParts

        if status = HttpStatusCode.OK then
            MeListRefFriends.OK(Serializer.deserialize content)
        else
            MeListRefFriends.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Create new navigation property ref to Friends for Me
    ///</summary>
    member this.MeCreateRefFriends() =
        let requestParts = []

        let (status, content) =
            OpenApiHttp.post httpClient "/Me/Friends/$ref" requestParts

        if status = HttpStatusCode.Created then
            MeCreateRefFriends.Created
        else
            MeCreateRefFriends.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetFavoriteAirline
    ///</summary>
    member this.MeGetFavoriteAirline() =
        let requestParts = []

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/Me/Microsoft.OData.SampleService.Models.TripPin.GetFavoriteAirline()"
                requestParts

        if status = HttpStatusCode.OK then
            MeGetFavoriteAirline.OK(Serializer.deserialize content)
        else
            MeGetFavoriteAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetFriendsTrips
    ///</summary>
    ///<param name="userName">Usage: userName={userName}</param>
    member this.MeGetFriendsTrips(userName: string) =
        let requestParts =
            [ RequestPart.path ("userName", userName) ]

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/Me/Microsoft.OData.SampleService.Models.TripPin.GetFriendsTrips(userName={userName})"
                requestParts

        if status = HttpStatusCode.OK then
            MeGetFriendsTrips.OK(Serializer.deserialize content)
        else
            MeGetFriendsTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke action ShareTrip
    ///</summary>
    member this.MeShareTrip(body: MeShareTripPayload) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Me/Microsoft.OData.SampleService.Models.TripPin.ShareTrip" requestParts

        if status = HttpStatusCode.NoContent then
            MeShareTrip.NoContent
        else
            MeShareTrip.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Photo from Me
    ///</summary>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeGetPhoto(?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Photo" requestParts

        if status = HttpStatusCode.OK then
            MeGetPhoto.OK(Serializer.deserialize content)
        else
            MeGetPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get ref of Photo from Me
    ///</summary>
    member this.MeGetRefPhoto() =
        let requestParts = []

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Photo/$ref" requestParts

        if status = HttpStatusCode.OK then
            MeGetRefPhoto.OK content
        else
            MeGetRefPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update the ref of navigation property Photo in Me
    ///</summary>
    member this.MeUpdateRefPhoto() =
        let requestParts = []

        let (status, content) =
            OpenApiHttp.put httpClient "/Me/Photo/$ref" requestParts

        if status = HttpStatusCode.NoContent then
            MeUpdateRefPhoto.NoContent
        else
            MeUpdateRefPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete ref of navigation property Photo for Me
    ///</summary>
    ///<param name="ifMatch">ETag</param>
    member this.MeDeleteRefPhoto(?ifMatch: string) =
        let requestParts =
            [ if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/Me/Photo/$ref" requestParts

        if status = HttpStatusCode.NoContent then
            MeDeleteRefPhoto.NoContent
        else
            MeDeleteRefPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Trips from Me
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeListTrips
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips" requestParts

        if status = HttpStatusCode.OK then
            MeListTrips.OK(Serializer.deserialize content)
        else
            MeListTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Create new navigation property to Trips for Me
    ///</summary>
    member this.MeCreateTrips(body: MicrosoftODataSampleServiceModelsTripPinTrip) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Me/Trips" requestParts

        if status = HttpStatusCode.Created then
            MeCreateTrips.Created(Serializer.deserialize content)
        else
            MeCreateTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Trips from Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeGetTrips(tripId: int, ?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips({TripId})" requestParts

        if status = HttpStatusCode.OK then
            MeGetTrips.OK(Serializer.deserialize content)
        else
            MeGetTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update the navigation property Trips in Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="body"></param>
    member this.MeUpdateTrips(tripId: int, body: MicrosoftODataSampleServiceModelsTripPinTrip) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Me/Trips({TripId})" requestParts

        if status = HttpStatusCode.NoContent then
            MeUpdateTrips.NoContent
        else
            MeUpdateTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete navigation property Trips for Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="ifMatch">ETag</param>
    member this.MeDeleteTrips(tripId: int, ?ifMatch: string) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/Me/Trips({TripId})" requestParts

        if status = HttpStatusCode.NoContent then
            MeDeleteTrips.NoContent
        else
            MeDeleteTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetInvolvedPeople
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    member this.MeTripsTripGetInvolvedPeople(tripId: int) =
        let requestParts = [ RequestPart.path ("TripId", tripId) ]

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/Me/Trips({TripId})/Microsoft.OData.SampleService.Models.TripPin.GetInvolvedPeople()"
                requestParts

        if status = HttpStatusCode.OK then
            MeTripsTripGetInvolvedPeople.OK(Serializer.deserialize content)
        else
            MeTripsTripGetInvolvedPeople.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Photos from Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeTripsListPhotos
        (
            tripId: int,
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips({TripId})/Photos" requestParts

        if status = HttpStatusCode.OK then
            MeTripsListPhotos.OK(Serializer.deserialize content)
        else
            MeTripsListPhotos.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get ref of Photos from Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    member this.MeTripsListRefPhotos
        (
            tripId: int,
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>
        ) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips({TripId})/Photos/$ref" requestParts

        if status = HttpStatusCode.OK then
            MeTripsListRefPhotos.OK(Serializer.deserialize content)
        else
            MeTripsListRefPhotos.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Create new navigation property ref to Photos for Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    member this.MeTripsCreateRefPhotos(tripId: int) =
        let requestParts = [ RequestPart.path ("TripId", tripId) ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Me/Trips({TripId})/Photos/$ref" requestParts

        if status = HttpStatusCode.Created then
            MeTripsCreateRefPhotos.Created
        else
            MeTripsCreateRefPhotos.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get PlanItems from Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeTripsListPlanItems
        (
            tripId: int,
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips({TripId})/PlanItems" requestParts

        if status = HttpStatusCode.OK then
            MeTripsListPlanItems.OK(Serializer.deserialize content)
        else
            MeTripsListPlanItems.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Create new navigation property to PlanItems for Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="body"></param>
    member this.MeTripsCreatePlanItems(tripId: int, body: MicrosoftODataSampleServiceModelsTripPinPlanItem) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Me/Trips({TripId})/PlanItems" requestParts

        if status = HttpStatusCode.Created then
            MeTripsCreatePlanItems.Created(Serializer.deserialize content)
        else
            MeTripsCreatePlanItems.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get PlanItems from Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="planItemId">key: PlanItemId of PlanItem</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.MeTripsGetPlanItems(tripId: int, planItemId: int, ?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              RequestPart.path ("PlanItemId", planItemId)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Me/Trips({TripId})/PlanItems({PlanItemId})" requestParts

        if status = HttpStatusCode.OK then
            MeTripsGetPlanItems.OK(Serializer.deserialize content)
        else
            MeTripsGetPlanItems.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update the navigation property PlanItems in Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="planItemId">key: PlanItemId of PlanItem</param>
    ///<param name="body"></param>
    member this.MeTripsUpdatePlanItems
        (
            tripId: int,
            planItemId: int,
            body: MicrosoftODataSampleServiceModelsTripPinPlanItem
        ) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              RequestPart.path ("PlanItemId", planItemId)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Me/Trips({TripId})/PlanItems({PlanItemId})" requestParts

        if status = HttpStatusCode.NoContent then
            MeTripsUpdatePlanItems.NoContent
        else
            MeTripsUpdatePlanItems.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete navigation property PlanItems for Me
    ///</summary>
    ///<param name="tripId">key: TripId of Trip</param>
    ///<param name="planItemId">key: PlanItemId of PlanItem</param>
    ///<param name="ifMatch">ETag</param>
    member this.MeTripsDeletePlanItems(tripId: int, planItemId: int, ?ifMatch: string) =
        let requestParts =
            [ RequestPart.path ("TripId", tripId)
              RequestPart.path ("PlanItemId", planItemId)
              if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/Me/Trips({TripId})/PlanItems({PlanItemId})" requestParts

        if status = HttpStatusCode.NoContent then
            MeTripsDeletePlanItems.NoContent
        else
            MeTripsDeletePlanItems.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entities from People
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="expand">Expand related entities</param>
    member this.PeoplePersonListPerson
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/People" requestParts

        if status = HttpStatusCode.OK then
            PeoplePersonListPerson.OK(Serializer.deserialize content)
        else
            PeoplePersonListPerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Add new entity to People
    ///</summary>
    member this.PeoplePersonCreatePerson(body: MicrosoftODataSampleServiceModelsTripPinPerson) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/People" requestParts

        if status = HttpStatusCode.Created then
            PeoplePersonCreatePerson.Created(Serializer.deserialize content)
        else
            PeoplePersonCreatePerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entity from People by key
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="expand">Expand related entities</param>
    member this.PeoplePersonGetPerson(userName: string, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/People({UserName})" requestParts

        if status = HttpStatusCode.OK then
            PeoplePersonGetPerson.OK(Serializer.deserialize content)
        else
            PeoplePersonGetPerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update entity in People
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="body"></param>
    member this.PeoplePersonUpdatePerson(userName: string, body: MicrosoftODataSampleServiceModelsTripPinPerson) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/People({UserName})" requestParts

        if status = HttpStatusCode.NoContent then
            PeoplePersonUpdatePerson.NoContent
        else
            PeoplePersonUpdatePerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete entity from People
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="ifMatch">ETag</param>
    member this.PeoplePersonDeletePerson(userName: string, ?ifMatch: string) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/People({UserName})" requestParts

        if status = HttpStatusCode.NoContent then
            PeoplePersonDeletePerson.NoContent
        else
            PeoplePersonDeletePerson.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get Friends from People
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.PeopleListFriends
        (
            userName: string,
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/People({UserName})/Friends" requestParts

        if status = HttpStatusCode.OK then
            PeopleListFriends.OK(Serializer.deserialize content)
        else
            PeopleListFriends.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetFavoriteAirline
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    member this.PeoplePersonGetFavoriteAirline(userName: string) =
        let requestParts =
            [ RequestPart.path ("UserName", userName) ]

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/People({UserName})/Microsoft.OData.SampleService.Models.TripPin.GetFavoriteAirline()"
                requestParts

        if status = HttpStatusCode.OK then
            PeoplePersonGetFavoriteAirline.OK(Serializer.deserialize content)
        else
            PeoplePersonGetFavoriteAirline.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetFriendsTrips
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="userNameInPath">Usage: userName={userName}</param>
    member this.PeoplePersonGetFriendsTrips(userName: string, userNameInPath: string) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              RequestPart.path ("userName", userNameInPath) ]

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/People({UserName})/Microsoft.OData.SampleService.Models.TripPin.GetFriendsTrips(userName={userName})"
                requestParts

        if status = HttpStatusCode.OK then
            PeoplePersonGetFriendsTrips.OK(Serializer.deserialize content)
        else
            PeoplePersonGetFriendsTrips.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke action ShareTrip
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="body"></param>
    member this.PeoplePersonShareTrip(userName: string, body: PeoplePersonShareTripPayload) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post
                httpClient
                "/People({UserName})/Microsoft.OData.SampleService.Models.TripPin.ShareTrip"
                requestParts

        if status = HttpStatusCode.NoContent then
            PeoplePersonShareTrip.NoContent
        else
            PeoplePersonShareTrip.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke function GetInvolvedPeople
    ///</summary>
    ///<param name="userName">key: UserName of Person</param>
    ///<param name="tripId">key: TripId of Trip</param>
    member this.PeoplePersonTripsTripGetInvolvedPeople(userName: string, tripId: int) =
        let requestParts =
            [ RequestPart.path ("UserName", userName)
              RequestPart.path ("TripId", tripId) ]

        let (status, content) =
            OpenApiHttp.get
                httpClient
                "/People({UserName})/Trips({TripId})/Microsoft.OData.SampleService.Models.TripPin.GetInvolvedPeople()"
                requestParts

        if status = HttpStatusCode.OK then
            PeoplePersonTripsTripGetInvolvedPeople.OK(Serializer.deserialize content)
        else
            PeoplePersonTripsTripGetInvolvedPeople.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entities from Photos
    ///</summary>
    ///<param name="top">Show only the first n items</param>
    ///<param name="skip">Skip the first n items</param>
    ///<param name="search">Search items by search phrases</param>
    ///<param name="filter">Filter items by property values</param>
    ///<param name="count">Include count of items</param>
    ///<param name="orderby">Order items by property values</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.PhotosPhotoListPhoto
        (
            ?top: int,
            ?skip: int,
            ?search: string,
            ?filter: string,
            ?count: bool,
            ?orderby: list<string>,
            ?select: list<string>,
            ?expand: list<string>
        ) =
        let requestParts =
            [ if top.IsSome then
                  RequestPart.query ("$top", top.Value)
              if skip.IsSome then
                  RequestPart.query ("$skip", skip.Value)
              if search.IsSome then
                  RequestPart.query ("$search", search.Value)
              if filter.IsSome then
                  RequestPart.query ("$filter", filter.Value)
              if count.IsSome then
                  RequestPart.query ("$count", count.Value)
              if orderby.IsSome then
                  RequestPart.query ("$orderby", orderby.Value)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Photos" requestParts

        if status = HttpStatusCode.OK then
            PhotosPhotoListPhoto.OK(Serializer.deserialize content)
        else
            PhotosPhotoListPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Add new entity to Photos
    ///</summary>
    member this.PhotosPhotoCreatePhoto(body: MicrosoftODataSampleServiceModelsTripPinPhoto) =
        let requestParts = [ RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.post httpClient "/Photos" requestParts

        if status = HttpStatusCode.Created then
            PhotosPhotoCreatePhoto.Created(Serializer.deserialize content)
        else
            PhotosPhotoCreatePhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get entity from Photos by key
    ///</summary>
    ///<param name="id">key: Id of Photo</param>
    ///<param name="select">Select properties to be returned</param>
    ///<param name="expand">Expand related entities</param>
    member this.PhotosPhotoGetPhoto(id: int64, ?select: list<string>, ?expand: list<string>) =
        let requestParts =
            [ RequestPart.path ("Id", id)
              if select.IsSome then
                  RequestPart.query ("$select", select.Value)
              if expand.IsSome then
                  RequestPart.query ("$expand", expand.Value) ]

        let (status, content) =
            OpenApiHttp.get httpClient "/Photos({Id})" requestParts

        if status = HttpStatusCode.OK then
            PhotosPhotoGetPhoto.OK(Serializer.deserialize content)
        else
            PhotosPhotoGetPhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update entity in Photos
    ///</summary>
    ///<param name="id">key: Id of Photo</param>
    ///<param name="body"></param>
    member this.PhotosPhotoUpdatePhoto(id: int64, body: MicrosoftODataSampleServiceModelsTripPinPhoto) =
        let requestParts =
            [ RequestPart.path ("Id", id)
              RequestPart.jsonContent body ]

        let (status, content) =
            OpenApiHttp.patch httpClient "/Photos({Id})" requestParts

        if status = HttpStatusCode.NoContent then
            PhotosPhotoUpdatePhoto.NoContent
        else
            PhotosPhotoUpdatePhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Delete entity from Photos
    ///</summary>
    ///<param name="id">key: Id of Photo</param>
    ///<param name="ifMatch">ETag</param>
    member this.PhotosPhotoDeletePhoto(id: int64, ?ifMatch: string) =
        let requestParts =
            [ RequestPart.path ("Id", id)
              if ifMatch.IsSome then
                  RequestPart.header ("If-Match", ifMatch.Value) ]

        let (status, content) =
            OpenApiHttp.delete httpClient "/Photos({Id})" requestParts

        if status = HttpStatusCode.NoContent then
            PhotosPhotoDeletePhoto.NoContent
        else
            PhotosPhotoDeletePhoto.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Get media content for Photo from Photos
    ///</summary>
    ///<param name="id">key: Id of Photo</param>
    member this.PhotosPhotoGetContent(id: int64) =
        let requestParts = [ RequestPart.path ("Id", id) ]

        let (status, contentBinary) =
            OpenApiHttp.getBinary httpClient "/Photos({Id})/$value" requestParts

        if status = HttpStatusCode.OK then
            PhotosPhotoGetContent.OK contentBinary
        else
            let content = Encoding.UTF8.GetString contentBinary
            PhotosPhotoGetContent.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Update media content for Photo in Photos
    ///</summary>
    ///<param name="id">key: Id of Photo</param>
    ///<param name="requestBody"></param>
    member this.PhotosPhotoUpdateContent(id: int64, ?requestBody: byte []) =
        let requestParts =
            [ RequestPart.path ("Id", id)
              if requestBody.IsSome then
                  RequestPart.binaryContent requestBody.Value ]

        let (status, content) =
            OpenApiHttp.put httpClient "/Photos({Id})/$value" requestParts

        if status = HttpStatusCode.NoContent then
            PhotosPhotoUpdateContent.NoContent
        else
            PhotosPhotoUpdateContent.DefaultResponse(Serializer.deserialize content)

    ///<summary>
    ///Invoke actionImport ResetDataSource
    ///</summary>
    member this.ActionImportResetDataSource() =
        let requestParts = []

        let (status, content) =
            OpenApiHttp.post httpClient "/ResetDataSource" requestParts

        if status = HttpStatusCode.NoContent then
            ActionImportResetDataSource.NoContent
        else
            ActionImportResetDataSource.DefaultResponse(Serializer.deserialize content)
