﻿using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.IO;
using MediaBrowser.Controller.Dlna;
using MediaBrowser.Model.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MediaBrowser.Dlna
{
    public class DlnaManager : IDlnaManager
    {
        private IApplicationPaths _appPaths;
        private readonly IXmlSerializer _xmlSerializer;
        private readonly IFileSystem _fileSystem;

        public DlnaManager(IXmlSerializer xmlSerializer, IFileSystem fileSystem)
        {
            _xmlSerializer = xmlSerializer;
            _fileSystem = fileSystem;

            //GetProfiles();
        }

        public IEnumerable<DeviceProfile> GetProfiles()
        {
            var list = new List<DeviceProfile>();

            list.Add(new DeviceProfile
            {
                Name = "Samsung TV (B Series)",
                ClientType = "DLNA",
                FriendlyName = "^TV$",
                ModelNumber = @"1\.0",
                ModelName = "Samsung DTV DMR",

                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                     new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mkv"}, 
                        MimeType = "x-mkv", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        MimeType = "x-msvideo", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp4"},                       
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                Name = "Samsung TV (E/F-series)",
                ClientType = "DLNA",
                FriendlyName = @"(^\[TV\][A-Z]{2}\d{2}(E|F)[A-Z]?\d{3,4}.*)|^\[TV\] Samsung",
                ModelNumber = @"(1\.0)|(AllShare1\.0)",

                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                    new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mkv"}, 
                        MimeType = "x-mkv", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        MimeType = "x-msvideo", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp4"},                       
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                Name = "Samsung TV (C/D-series)",
                ClientType = "DLNA",
                FriendlyName = @"(^TV-\d{2}C\d{3}.*)|(^\[TV\][A-Z]{2}\d{2}(D)[A-Z]?\d{3,4}.*)|^\[TV\] Samsung",
                ModelNumber = @"(1\.0)|(AllShare1\.0)",
                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                     new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },                  
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mkv"}, 
                        MimeType = "x-mkv", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        MimeType = "x-msvideo", 
                        Type = DlnaProfileType.Video
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp4"},                       
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                Name = "Xbox 360",
                ClientType = "DLNA",
                ModelName = "Xbox 360",
                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                    new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        MimeType = "x-msvideo", 
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                Name = "Xbox One",
                ModelName = "Xbox One",
                ClientType = "DLNA",
                FriendlyName = "Xbox-SystemOS",
                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                    new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        MimeType = "x-msvideo", 
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                Name = "Sony Bravia (2012)",
                ClientType = "DLNA",
                FriendlyName = @"BRAVIA KDL-\d{2}[A-Z]X\d5(\d|G).*",

                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                    new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3"}, 
                        Type = DlnaProfileType.Audio
                    },
                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi"}, 
                        Type = DlnaProfileType.Video,
                        MimeType = "avi"
                    }
                }
            });

            //WDTV does not need any transcoding of the formats we support statically
            list.Add(new DeviceProfile
            {
                Name = "WDTV Live",
                ClientType = "DLNA",
                ModelName = "WD TV HD Live",

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3", "flac", "m4a", "wma"}, 
                        Type = DlnaProfileType.Audio
                    },

                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi", "mp4", "mkv", "ts"}, 
                        Type = DlnaProfileType.Video
                    }
                }
            });

            list.Add(new DeviceProfile
            {
                //Linksys DMA2100us does not need any transcoding of the formats we support statically
                Name = "Linksys DMA2100",
                ClientType = "DLNA",
                ModelName = "DMA2100us",

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3", "flac", "m4a", "wma"}, 
                        Type = DlnaProfileType.Audio
                    },

                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi", "mp4", "mkv", "ts"}, 
                        Type = DlnaProfileType.Video
                    }
                }
            });

            foreach (var item in list)
            {
                //_xmlSerializer.SerializeToFile(item, "d:\\" + _fileSystem.GetValidFilename(item.Name));
            }

            return list;
        }

        public DeviceProfile GetDefaultProfile()
        {
            return new DeviceProfile
            {
                TranscodingProfiles = new[]
                {
                    new TranscodingProfile
                    {
                        Container = "mp3", 
                        Type = DlnaProfileType.Audio
                    },
                    new TranscodingProfile
                    {
                        Container = "ts", 
                        Type = DlnaProfileType.Video
                    }
                },

                DirectPlayProfiles = new[]
                {
                    new DirectPlayProfile
                    {
                        Containers = new[]{"mp3", "wma"}, 
                        Type = DlnaProfileType.Audio
                    },

                    new DirectPlayProfile
                    {
                        Containers = new[]{"avi", "mp4"}, 
                        Type = DlnaProfileType.Video
                    }
                }
            };
        }

        public DeviceProfile GetProfile(string friendlyName, string modelName, string modelNumber)
        {
            foreach (var profile in GetProfiles())
            {
                if (!string.IsNullOrEmpty(profile.FriendlyName))
                {
                    if (!Regex.IsMatch(friendlyName, profile.FriendlyName))
                        continue;
                }

                if (!string.IsNullOrEmpty(profile.ModelNumber))
                {
                    if (!Regex.IsMatch(modelNumber, profile.ModelNumber))
                        continue;
                }

                if (!string.IsNullOrEmpty(profile.ModelName))
                {
                    if (!Regex.IsMatch(modelName, profile.ModelName))
                        continue;
                }

                return profile;

            }
            return GetDefaultProfile();
        }
    }
}