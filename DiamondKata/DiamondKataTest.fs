namespace DiamondKata

open NUnit.Framework;
open FsCheck;
open FsUnit;
open System;
open diamondKata;

[<TestFixture>]
module diamondkataTest = 
    let split (diamond: string) = 
        diamond.Split([| Environment.NewLine |], StringSplitOptions.None)

    let trim (x:string) = x.Trim()

    let ``The first letter should be A`` (diamond : string) =
        let rows = split diamond
        rows |> Seq.head |> trim = "A"

    let ``The last letter should be A`` (diamond : string) =
        let rows = split diamond
        rows |> Seq.last |> trim = "A"
            
    type Letters =
        static member Char() = Gen.elements ['A' .. 'Z'] |> Arb.fromGen

    [<Test>]
    let ``The first letter should be A unit test`` =
        let property char =
            diamondGenerator char |> ``The first letter should be A``

        Check.QuickThrowOnFailure (property)
    
    [<Test>]
    let ``The last letter should be A unit test`` =
        let property char =
            diamondGenerator char |> ``The first letter should be A``

        Check.QuickThrowOnFailure (property)