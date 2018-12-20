﻿using System;
using System.Threading;

namespace Xamarin.Forms.OpenTok.Service
{
    public sealed class CrossOpenTok
    {
        private static bool _isInitialized;
        private static Lazy<IOpenTokService> _implementation;

        public static void Initialize(Func<IOpenTokService> creator)
        {
            if(_isInitialized)
            {
                return;
            }
            _isInitialized = true;
            _implementation = new Lazy<IOpenTokService>(creator, LazyThreadSafetyMode.PublicationOnly);
        }

        public static IOpenTokService Current
        {
            get
            {
                var value = _implementation.Value;
                if (value == null)
                {
                    throw new NotImplementedException("You must call PlatformOpenTokService.Init() in platform specific code before using it.");
                }
                return value;
            }
        }
    }
}
