using TI.CMD.FX.Ansi.Interfaces;

namespace TI.CMD.FX.Ansi.Builder
{
    public class AnsiStringColorBuilder : IAnsiColorBuilder
    {
        private readonly ColorBuilder Builder;

        public string CurrentValue { get; private set; }
        public AnsiStringColorBuilder(string text)
        {
            CurrentValue = text;
            Builder = new ColorBuilder(this);
        }


        public string Reset()
        {
            return AnsiCodes.Reset;
        }

        public string Build()
        {
            return CurrentValue + Reset();
        }

        #region Color Modes
        public IAnsiColors Foregorund
        {

            get
            {
                Builder.Foreground();
                return Builder;
            }

        }
        public IAnsiColors Background
        {

            get
            {
                Builder.Background();
                return Builder;
            }

        }
        #endregion

        private class ColorBuilder : IAnsiColors
        {
            readonly AnsiStringColorBuilder Instance;
            private string currentColorModeCode;


            public ColorBuilder(AnsiStringColorBuilder instance)
            {
                Instance = instance;
            }

            public void Foreground()
            {
                currentColorModeCode = AnsiCodes.Colors.ForegroundCode;
            }
            public void Background()
            {
                currentColorModeCode = AnsiCodes.Colors.BackgroundCode;
            }



            #region Color Definitions

            public IAnsiColorBuilder RedColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Red}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder BlackColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Black}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder GreenColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Green}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder YellowColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Yellow}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder BlueColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Blue}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder MagentaColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Magenta}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder CyanColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.Cyan}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public IAnsiColorBuilder WhiteColor()
            {
                {
                    Instance.CurrentValue = $"{currentColorModeCode}{AnsiCodes.Colors.White}{Instance.CurrentValue}";
                    return Instance;
                }
            }

            public string Black()
            {
                return this.BlackColor().Build();
            }

            public string Red()
            {
                return this.RedColor().Build();
            }

            public string Green()
            {
                return this.GreenColor().Build();
            }

            public string Yellow()
            {
                return this.YellowColor().Build();
            }

            public string Blue()
            {
                return this.BlueColor().Build();
            }

            public string Magenta()
            {
                return this.MagentaColor().Build();
            }

            public string Cyan()
            {
                return this.CyanColor().Build();
            }

            public string White()
            {
                return this.WhiteColor().Build();
            }





            #endregion
        }

    }
}
