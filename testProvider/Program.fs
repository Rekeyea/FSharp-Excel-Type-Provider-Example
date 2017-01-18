// Más información acerca de F# en http://fsharp.org
// Vea el proyecto "Tutorial de F#" para obtener más ayuda.
module Provider

open FSharp.ExcelProvider
open System
open libreria

type ExcelType = ExcelFile<"typeOfExcel.xlsx">

let mapExcelRowToProduct (x:ExcelType.Row) = 
    let product = Product()
    product.Name <- x.``Product Name``
    product.Description <- x.Description
    product.ExpectedEarnings <- (x.Price / x.Cost) * 100.0
    product.Value <- x.Price
    product


let mapExcelToProducts() = 
    let file = ExcelType("./../../sample.xlsx")
    let values = 
        file.Data
        |> Seq.where (fun (x:ExcelType.Row) -> not(String.IsNullOrEmpty((string)x.``Product Name``)))
        |> Seq.map mapExcelRowToProduct
    values

[<EntryPoint>]
let main argv = 
    let values = mapExcelToProducts()
    let result = String.Join(Environment.NewLine, values |> Seq.map (fun x -> x.ToString()))
    printfn "%s" result
    Console.ReadLine() |> ignore
    0 // return an integer exit code
