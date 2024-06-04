﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vinyl_Store.ServiceReference1 {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebService1Soap")]
    public interface WebService1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAlbums", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetAlbums();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAlbums", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetAlbumsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSongs", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetSongs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSongs", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetSongsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddAlbums", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void AddAlbums(int Id_Album, string NumeAlbum, string CuloareCd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddAlbums", ReplyAction="*")]
        System.Threading.Tasks.Task AddAlbumsAsync(int Id_Album, string NumeAlbum, string CuloareCd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddSongs", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void AddSongs(int Id_Cantec, string TitluCantec, string Album);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddSongs", ReplyAction="*")]
        System.Threading.Tasks.Task AddSongsAsync(int Id_Cantec, string TitluCantec, string Album);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteAlbum", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DeleteAlbum(int Id_Album);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteAlbum", ReplyAction="*")]
        System.Threading.Tasks.Task DeleteAlbumAsync(int Id_Album);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSong", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DeleteSong(int Id_Cantec);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSong", ReplyAction="*")]
        System.Threading.Tasks.Task DeleteSongAsync(int Id_Cantec);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAlbumsByColor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] GetAlbumsByColor(string color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAlbumsByColor", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> GetAlbumsByColorAsync(string color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSongsByAlbum", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] GetSongsByAlbum(string albumName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSongsByAlbum", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> GetSongsByAlbumAsync(string albumName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateAlbum", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UpdateAlbum(int Id_Album, string NumeAlbum, string CuloareCd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateAlbum", ReplyAction="*")]
        System.Threading.Tasks.Task UpdateAlbumAsync(int Id_Album, string NumeAlbum, string CuloareCd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : Vinyl_Store.ServiceReference1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<Vinyl_Store.ServiceReference1.WebService1Soap>, Vinyl_Store.ServiceReference1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public System.Data.DataSet GetAlbums() {
            return base.Channel.GetAlbums();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetAlbumsAsync() {
            return base.Channel.GetAlbumsAsync();
        }
        
        public System.Data.DataSet GetSongs() {
            return base.Channel.GetSongs();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetSongsAsync() {
            return base.Channel.GetSongsAsync();
        }
        
        public void AddAlbums(int Id_Album, string NumeAlbum, string CuloareCd) {
            base.Channel.AddAlbums(Id_Album, NumeAlbum, CuloareCd);
        }
        
        public System.Threading.Tasks.Task AddAlbumsAsync(int Id_Album, string NumeAlbum, string CuloareCd) {
            return base.Channel.AddAlbumsAsync(Id_Album, NumeAlbum, CuloareCd);
        }
        
        public void AddSongs(int Id_Cantec, string TitluCantec, string Album) {
            base.Channel.AddSongs(Id_Cantec, TitluCantec, Album);
        }
        
        public System.Threading.Tasks.Task AddSongsAsync(int Id_Cantec, string TitluCantec, string Album) {
            return base.Channel.AddSongsAsync(Id_Cantec, TitluCantec, Album);
        }
        
        public void DeleteAlbum(int Id_Album) {
            base.Channel.DeleteAlbum(Id_Album);
        }
        
        public System.Threading.Tasks.Task DeleteAlbumAsync(int Id_Album) {
            return base.Channel.DeleteAlbumAsync(Id_Album);
        }
        
        public void DeleteSong(int Id_Cantec) {
            base.Channel.DeleteSong(Id_Cantec);
        }
        
        public System.Threading.Tasks.Task DeleteSongAsync(int Id_Cantec) {
            return base.Channel.DeleteSongAsync(Id_Cantec);
        }
        
        public string[] GetAlbumsByColor(string color) {
            return base.Channel.GetAlbumsByColor(color);
        }
        
        public System.Threading.Tasks.Task<string[]> GetAlbumsByColorAsync(string color) {
            return base.Channel.GetAlbumsByColorAsync(color);
        }
        
        public string[] GetSongsByAlbum(string albumName) {
            return base.Channel.GetSongsByAlbum(albumName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetSongsByAlbumAsync(string albumName) {
            return base.Channel.GetSongsByAlbumAsync(albumName);
        }
        
        public void UpdateAlbum(int Id_Album, string NumeAlbum, string CuloareCd) {
            base.Channel.UpdateAlbum(Id_Album, NumeAlbum, CuloareCd);
        }
        
        public System.Threading.Tasks.Task UpdateAlbumAsync(int Id_Album, string NumeAlbum, string CuloareCd) {
            return base.Channel.UpdateAlbumAsync(Id_Album, NumeAlbum, CuloareCd);
        }
    }
}