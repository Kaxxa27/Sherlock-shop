﻿namespace SherlockShop.WEB;

public static class SD
{
    public static string ProductAPIBase { get; set; }

    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
