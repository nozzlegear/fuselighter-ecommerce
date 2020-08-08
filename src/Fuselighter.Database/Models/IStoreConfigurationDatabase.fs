namespace Fuselighter.Database.Models

open System.Threading.Tasks

type IStoreConfigurationDatabase =
    abstract member ConfigureAsync: StoreConfiguration -> Task<StoreConfiguration>
    abstract member GetAsync: unit -> Task<StoreConfiguration option>
