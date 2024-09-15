﻿using PictureLibrary.Client.Clients.Libraries;
using PictureLibrary.Client.Clients.Tags;
using PictureLibrary.Client.Clients.Users;

namespace PictureLibrary.Client
{
    public interface IPictureLibraryApiClient
    {
        ILibrariesClient Libraries();
        ITagsClient Tags();
        IUsersClient Users();
    }
}