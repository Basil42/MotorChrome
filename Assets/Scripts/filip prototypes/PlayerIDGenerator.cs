using System;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class PlayerIDGenerator : MonoBehaviour
{
    //Asked chatgpt to generate 200x 3-letter words that were random and could not be considered bad
    private List<string> playerIDPool = new List<string>()
                            { "JYX", "GQM", "ZWK", "XST", "PKH", "OMN", "VLF", "WDC", "XEQ", "JAO",
                        "BFG", "NXB", "DBZ", "IXL", "VZY", "LPU", "WYV", "JET", "QPD", "WIX",
                        "VMZ", "NZW", "NAR", "WOT", "BSX", "UJK", "GHI", "ROV", "QWS", "CKU",
                        "FED", "DLH", "QNA", "XYM", "KAT", "UZW", "LQV", "MSO", "POY", "IHU",
                        "TGJ", "DPC", "ZFL", "ORC", "VYD", "BVK", "ZPJ", "URS", "TIJ", "PQB",
                        "RFM", "HXW", "AVK", "MGC", "QEN", "UHP", "CSN", "TDU", "GRC", "ELV",
                        "AWB", "OQY", "DBY", "JUN", "VEY", "WJL", "GFA", "IHX", "VOC", "AXY",
                        "JNL", "TRQ", "OPW", "LWV", "YKP", "RDZ", "MSH", "NGL", "DYW", "FEM",
                        "WAT", "RKX", "VDK", "NQU", "ACR", "BVH", "PTO", "XGK", "LSN", "JUI",
                        "CEQ", "YLR", "ORX", "MFA", "EZW", "IGX", "KWL", "UVG", "THJ", "ZTZ",
                        "XVN", "BPD", "WBO", "FQV", "UVR", "NMY", "PVT", "LKO", "IHW", "APD",
                        "ZGF", "CSX", "KZF", "WJZ", "NVI", "RPT", "MUJ", "YGM", "VBT", "EIK",
                        "WBC", "HXD", "LNJ", "IDY", "GUE", "QKZ", "ARM", "YDN", "OKL", "XTK",
                        "DZP", "BHY", "PWG", "JAF", "VCW", "MPT", "SRZ", "LHZ", "KWV", "OAG",
                        "XVF", "NFE", "GMH", "WQO", "DIX", "TJK", "RWE", "VQM", "ZLB", "YCS",
                        "FOK", "NAE", "LRA", "CZV", "BTE", "WPX", "IQA", "UOY", "HVL", "GXP",
                        "MXS", "ESV", "KPW", "VDY", "BLJ", "OZG", "HRM", "UTN", "WQD", "JCX",
                        "KSL", "EPB", "FJG", "VOP", "WYH", "TYR", "QDF", "NHF", "ZGU", "VUB",
                        "SPL", "XOM", "DAR", "LSE", "MXC", "RZL", "JYR", "BTI", "AKQ", "GWE",
                        "VDX", "ONZ", "HWU", "CXJ", "VNO", "WTL", "PVF", "FIC", "QYZ", "LAK",
                        "TBQ", "MSD", "ZNX", "REG", "WFA", "PXH", "IVO", "NKB", "EJL", "DJW",
                        "UYP", "YOF", "GHA", "KZL", "VXN", "WRU", "TQM", "SOA", "NPI", "LUG",
                        "WBV", "IAZ", "QEV", "RTK", "MXY", "GJP", "XCV", "DIU", "HNE", "LWJ",
                        "YPG", "OFX", "URM", "JQZ", "KHL", "ZRV", "SWT", "VLC", "NXT", "BCP",
                        "TXE", "QAF", "OGM", "MYI", "FNB", "LVP", "ZWI", "DKT", "RIA", "HJB"
                            };

    private string playerID;
    private int namePoolLowest = 0;
    private int namePoolHighest = 199;
    public string GeneratePlayerID()
    {
        Random random = new Random();
        int randomNumber = random.Next(namePoolLowest , namePoolHighest);
        playerID = playerIDPool[randomNumber];
        return playerID;
    }

}
