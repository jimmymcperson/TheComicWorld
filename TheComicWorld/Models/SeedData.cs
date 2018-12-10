using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TheComicWorld.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Mass Effect: Conviction",
                        Description = "Mass Effect: Conviction is an eight-page mini-comic that details how Alliance soldier James Vega came to be a part of Commander Shepard's trial on Earth.",
                        Year = "2011",
                        Author = "Mac Walters",
                        Category = "Dark Horse Comics",
                        Price = 10
                    },
                    new Product
                    {
                        Name = "Dragon Age Vol. 1",
                        Description = "Collects the entire six-issue Dragon Age miniseries! In a time lost to history, a war ravaged the land. Mages, incredibly powerful wielders of magic, ruled the world through mastery of dark arts and forbidden spells. Their lust for power almost destroyed all existence, and unleashed an unholy pestilence, the Darkspawn, to plague mankind, trolls, faeries, and all the inhabitants of the realm. Now magic is carefully controlled, taught behind the sacred walls of the Circle of Magi, and monitored by the ever-vigilant Templars. It is in this arena that a new generation of Mages in training will arise, warriors of sorcery who will defy the rules of the Templars and change the course of the world forever.",
                        Year = "2010",
                        Author = "Orson Scott Card and Aaron Johnston",
                        Category = "IDW Publishing",
                        Price = 14
                    },
                    new Product
                    {
                        Name = "The Witcher: Matters of Conscience",
                        Description = "The year was 1271. The place - Vergen. The moment - portentous. King Henselt's long siege had finally ended. Life was slowly retunring to normal - or as 'normal' as it could be in a city where humans, dwarves and elves lived side by side an din harmony, the whole powder keg led by a maiden... And not just any maiden, mind you, but the virgin and heroine Saskia, until recently known as the Dragonslayer, before she was revealed to be a dragon herself. Her true name was Saesenthessis, a name of some beauty. As to her true form... well, none could say, for she was of the rare breed endowed with the gift of polymorphy and could thus change her appearance as easily as others change stockings.",
                        Year = "2015",
                        Author = "Michal Galek",
                        Category = "CD Projekt RED",
                        Price = 10
                    },
                    new Product
                    {
                        Name = "Iron Man: Demon in a Bottle (TPB)",
                        Description = "A military tank hurled through the air strikes the wing of a passenger plane carrying Tony Stark. Stark secretly dons the Iron Man armor he carries in his briefcase, flies out of the plane, and guides it to a safe landing in the ocean. Navy ships approach and soldiers help the passengers to safety, and bring Iron Man to an island base. They tell him the tank was thrown by Namor, who was defending a resident of the island that the soldiers were trying to remove, because the island is used as a toxic waste disposal site. Iron Man confronts and fights Namor, before it's revealed that the soldiers actually belong to the Roxxon Oil Corporation, which is secretly occupying the island to mine the vibranium it contains.",
                        Year = "2006",
                        Author = "David Michelinie and Bob Layton",
                        Category = "Marvel Comics",
                        Price = 50
                    },
                    new Product
                    {
                        Name = "Thanos Quest (TPB)",
                        Description = "Recently resurrected by Death in order to wipe out half of the population of the universe, the Titan Thanos discovers the true nature of the six Infinity Gems after gazing into Death's Infinity Well. Convincing Death that possession of the gems will aid him tremendously in his quest, he gains her permission to seek them out from the cosmic entities that currently possess them.",
                        Year = "2012",
                        Author = "Jim Starlin",
                        Category = "Marvel Comics",
                        Price = 40
                    },
                    new Product
                    {
                        Name = "Gods and Mortals (TPB)",
                        Description = "A tale of the Amazons from 30,000 BC to now; a cavewoman, and her unborn daughter, are murdered by her mate. On Mount Olympus, Ares opposes Artemis' plans to create a new race of female mortals to set an example to other mortals, and Zeus doesn't care. Artemis and four other Goddesses go to the Cavern of Souls where they use all, except for one, the souls of perished women to create reborn, ageless Amazons. With their queens, Queen Hippolyta and Queen Antiope, the Amazons are successful but there is jealously from Greek kings.",
                        Year = "2004",
                        Author = "Greg Potter and Len Wein",
                        Category = "DC Comics",
                        Price = 60
                    },
                    new Product
                    {
                        Name = "Blackest Night (TPB)",
                        Description = "Green Lanterns Ash and Saarek find the Black Central Power Battery at a reportedly classified location within Sector 666. After touching the battery, Saarek reports that their presence has awoken something. The two are killed when two monstrous hands emerge from below them as the battery calls 'flesh'. In Green Lantern Corps, a field of asteroids in an unknown region of space is depicted with the colors of the spectrum in the background. The asteroids, which are apparently the remains of the planet Xanshi, are shattered and a large quantity of black power rings move through them.",
                        Year = "2010",
                        Author = "Geoff Johns",
                        Category = "DC Comics",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "Justice League: A League of One (TPB)",
                        Description = "In 1348, the evil dragon Drakul Karfang ravages a small band of crusaders, intent on destroying the beast. Hundreds of arrows litter the air, and one soldier lands a hard blow to the neck. Karfang flies off. The leader commands the men to follow Karfang to the ground in order to get her heart and destroy it. Destroying a dragon's heart is the only way to kill it. The soldiers reach a hidden dragon lair and attack, killing the minions of the dragons, which are smaller humanoid lizards. Unable to find the heart, they blow the door in, sealing the area.",
                        Year = "2015",
                        Author = "Christopher Moeller",
                        Category = "DC Comics",
                        Price = 85
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
