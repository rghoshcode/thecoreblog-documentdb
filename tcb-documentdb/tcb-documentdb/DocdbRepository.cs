using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace tcb_documentdb
{
    public class DocdbRepository<T> : IDocdbRepository<T> where T : class
    {
        private static readonly string DatabaseId = "TCBDB";
        private static readonly string CollectionId = "Collection1";
        private static readonly string AzureEndPoint = "https://rghoshcode.documents.azure.com:443/";
        private static readonly string AzureAuthKey = "RZvrS7f0KG4PjX19wHvBKv26G0ZNfrXppXuUOY2uMM1aOthbXliItaqGYFNgl8hiSU01RElxIMcjGrATB9zaQQ==";
        private static DocumentClient client;


        public void Initialize()
        {
            client = new DocumentClient(new Uri(AzureEndPoint),
                AzureAuthKey,
                new ConnectionPolicy { EnableEndpointDiscovery = false }
                );
            CreateDbIfNotExists().Wait();
            CreateCollectionIfNotExists().Wait();

        }

        private async Task CreateCollectionIfNotExists()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 }
                        );
                }
                else
                {
                    throw ex;
                }
            }
        }

        private async Task CreateDbIfNotExists()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch(DocumentClientException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw ex;
                }
            }
        }

        public async Task<Document> CreateAsync(T value)
        {
            try
            { 

            return await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), value);
            }
            catch (DocumentClientException ex)
            {
                throw ex;
            }

        }

        public Task<T> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(string id)
        {
            try
            {
                var uri = UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id);
                Document document = await client.ReadDocumentAsync(uri);
                return (T)(dynamic)document; 
            }
            catch (DocumentClientException ex)
            {
                throw ex;
            }
        }

        

        public Task<T> UpdateAsync(string id, T value)
        {
            throw new NotImplementedException();
        }
    }
}
