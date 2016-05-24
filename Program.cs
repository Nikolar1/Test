using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        public struct predmet
        {
            public int atk;
            public int def;
            public string ime;
        }
        public struct takmicar
        {
            public int atk;
            public int def;
            public int hp;
            public string ime;
            public int p1;
            public int p2;
            public int p3;
        }
        static void Main(string[] args)
        {
            Random r1 = new Random();
            takmicar[] tak = new takmicar[8];
            int i = 0;
            bool m = false;
            int r;
            int[] pr1 = new int[50];
            while (i < 50)
            {
                pr1[i] = 0;
                i++;
            }
            i = 0;
            int j = 0;
            while (i < 8)
            {
                tak[i].atk = r1.Next(1, 100);
                tak[i].def = r1.Next(1, 50);
                tak[i].hp = r1.Next(300, 500);
                tak[i].ime = "takmicar" + (i+1);
                r = r1.Next(1, 50);
                while (j < 50)
                {
                  if(pr1[j]==r)
                  {
                    m = false;
                  }           
                  j++;
                }
                tak[i].p1 = r;
                j = 0;
                r = r1.Next(1, 50);
                while (j < 50)
                {
                    if (pr1[j] == r)
                    {
                        m = false;
                    }
                    j++;
                }
                tak[i].p2 = r;
                j = 0;
                r = r1.Next(1, 50);
                while (j < 50)
                {
                    if (pr1[j] == r)
                    {
                        m = false;
                    }
                    j++;
                }
                tak[i].p3 = r;
                j = 0;
                i++;
            }
            i = 0;
            predmet[] pred = new predmet[50];
            while (i < 50)
            {
                pred[i].atk = r1.Next(1, 20);
                pred[i].def = r1.Next(1, 20);
                pred[i].ime = "p" + i+1;
                i++;
            }
            i= 0;
            while (i < 8)
            {
                tak[i].atk = tak[i].atk + pred[tak[i].p1].atk + pred[tak[i].p2].atk + pred[tak[i].p3].atk;
                tak[i].def = tak[i].def + pred[tak[i].p1].def + pred[tak[i].p2].def + pred[tak[i].p3].def;
                i++;
            }
            i = 0;
            j = 0;
            int h1;
            int h2;
            int[] pob = new int[4];
            while (i < 8)
            {
                m = true;
                h1=tak[i].hp;
                h2=tak[i+1].hp;
                while (m)
                {
                    h1 = h1 - (tak[i + 1].atk - tak[i].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp",tak[i+1].ime,tak[i].ime,tak[i+1].atk-tak[i].def,h1);
                    System.Threading.Thread.Sleep(1000);
                    if (h1 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}", tak[i+1].ime);
                        pob[j] = i + 1;
                        j++;
                        break;
                    }
                    h2 = h2 - (tak[i].atk - tak[i+1].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp", tak[i].ime, tak[i+1].ime, tak[i].atk - tak[i+1].def, h2);
                    System.Threading.Thread.Sleep(1000);
                    if (h2 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}", tak[i].ime);
                        pob[j] = i;
                        j++;
                        break;
                    }
                        if (tak[i].def >= tak[i + 1].atk && tak[i + 1].def >= tak[i].atk)
                        {
                            if (tak[i].hp > tak[i + 1].hp)
                            {
                                Console.WriteLine("Pobedio je {0}", tak[i].ime);
                                pob[j] = i;
                                j++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Pobedio je {0}", tak[i+1].ime);
                                pob[j] = i+1;
                                j++;
                                break;
                            }
                        }
                }
                i=i+2;
            }
            i = 0;
            j = 0;
            while (i < 4)
            {
                m = true;
                h1 = tak[pob[i]].hp;
                h2 = tak[pob[i]+1].hp;
                while (m)
                {
                    h1 = h1 - (tak[pob[i + 1]].atk - tak[pob[i]].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp", tak[pob[i + 1]].ime, tak[pob[i]].ime, tak[pob[i + 1]].atk - tak[pob[i]].def, h1);
                    System.Threading.Thread.Sleep(1000);
                    if (h1 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}", tak[pob[i+1]].ime);
                        pob[j] = pob[i + 1];
                        j++;
                        break;
                    }
                    h2 = h2 - (tak[pob[i]].atk - tak[pob[i] + 1].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp", tak[pob[i]].ime, tak[pob[i + 1]].ime, tak[pob[i]].atk - tak[pob[i + 1]].def, h2);
                    System.Threading.Thread.Sleep(1000);
                    if (h2 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}", tak[pob[i]].ime);
                        pob[j] = pob[i];
                        j++;
                        break;
                    }
                    if (tak[pob[i]].def >= tak[pob[i + 1]].atk && tak[pob[i + 1]].def >= tak[pob[i]].atk)
                    {
                        if (tak[pob[i]].hp > tak[pob[i + 1]].hp)
                        {
                            Console.WriteLine("Pobedio je {0}", tak[pob[i]].ime);
                            pob[j] = pob[i];
                            j++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pobedio je {0}", tak[pob[i+1]].ime);
                            pob[j] = pob[i+ 1];
                            j++;
                            break;
                        }
                    }
                }
                i=i+2;
            }
            i = 0;
            j = 0;
            while (i < 2)
            {
                m = true;
                h1 = tak[pob[i]].hp;
                h2 = tak[pob[i + 1]].hp;
                while (m)
                {
                    h1 = h1 - (tak[pob[i + 1]].atk - tak[pob[i]].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp", tak[pob[i + 1]].ime, tak[pob[i]].ime, tak[pob[i + 1]].atk - tak[pob[i]].def, h1);
                    System.Threading.Thread.Sleep(1000);
                    if (h1 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}",tak[pob[i+1]].ime);
                        j++;
                        break;
                    }
                    h2 = h2 - (tak[pob[i]].atk - tak[pob[i + 1]].def);
                    Console.WriteLine("{0} napada {1} i nanosi {2} stete a {1} sad ima {3} hp", tak[pob[i]].ime, tak[pob[i + 1]].ime, tak[pob[i]].atk - tak[pob[i + 1]].def, h2);
                    System.Threading.Thread.Sleep(1000);
                    if (h2 <= 0)
                    {
                        Console.WriteLine("Pobedio je {0}", tak[pob[i]].ime);
                        j++;
                        break;
                    }
                    if (tak[pob[i]].def >= tak[pob[i + 1]].atk && tak[pob[i + 1]].def >= tak[pob[i]].atk)
                    {
                        if (tak[pob[i]].hp > tak[pob[i + 1]].hp)
                        {
                            Console.WriteLine("Pobedio je {0}", tak[pob[i]].ime);
                            j++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pobedio je {0}", tak[pob[i+1]].ime);
                            j++;
                            break;
                        }
                    }
                }
                i=i+2;
            }
            Console.ReadLine();
        }
    }
}
