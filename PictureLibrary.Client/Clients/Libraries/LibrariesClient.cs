﻿using PictureLibrary.Client.Model;
using PictureLibrary.Client.Requests;

namespace PictureLibrary.Client.Clients.Libraries
{
    public class LibrariesClient(IApiHttpClient apiHttpClient)
    {
        public async Task<Library> GetLibrary(string id, AuthorizationData authorizationData)
        {
            return await apiHttpClient.Get<Library>($"library/get/{id}", authorizationData);
        }

        public async Task<AllLibraries> GetAllLibraries(AuthorizationData authorizationData)
        {
            return await apiHttpClient.Get<AllLibraries>("library/getall", authorizationData);
        }

        public async Task<Library> AddLibrary(AddLibraryRequest request, AuthorizationData authorizationData)
        {
            return await apiHttpClient.Post<Library>("library/create", request, authorizationData);
        }
    }
}