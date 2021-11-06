using System;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class MediaLibraryQueryGenerator : IMediaLibraryQueryGenerator
    {
        public string GetMediaLibraryQuery(IGetMediaLibraryParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.MediaLibrary_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddMediaLibraryFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddMediaLibraryFieldsParameters(IGetMediaLibraryParameters parameters, StringBuilder query)
        {
            // GetMediaLibraryParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("q", parameters.Query);
            query.AddParameterToQuery("media_type", parameters.MediaType);
        }
    }
}
