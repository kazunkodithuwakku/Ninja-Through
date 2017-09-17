using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Globals
    {
        private static bool isClickedOnPillar;
        private static int ninjaCount = 4;
        private static int clickedPillar = 0;
        private static int movingPillar = 0;

        public static int ninja1Location = 1;
        public static int ninja2Location = 2;
        public static int ninja3Location = 8;
        public static int ninja4Location = 10;

        public static int currentSelectedNinja = 0;

        //in this method user only allowed to click on pillars
        public static bool ClickValidation
        {
            get
            {
                return isClickedOnPillar;
            }
            set
            {
                isClickedOnPillar = value;
            }
        }

        //
        public static int CurrentlyClickedPillarID
        {
            get
            {
                return clickedPillar;
            }
            set
            {
                clickedPillar = value;
            }
        }



        public static int MovingPillarID
        {
            get
            {
                return movingPillar;
            }
            set
            {
                movingPillar = value;
            }
        }


        //this method keeps track on ninja count and check whether the player removes all ninjas
        public static void ManageNinjaCount()
        {
            ninjaCount = ninjaCount - 1;
            if (ninjaCount == 1)
            {
                Debug.Log("WIN");
            }
        }


        //this method returns the location of the selected ninja
        public static int GetCurrentSelectedNinjasPillarID()
        {
            if (currentSelectedNinja == 1)
                return ninja1Location;
            else if (currentSelectedNinja == 2)
                return ninja2Location;
            else if (currentSelectedNinja == 3)
                return ninja3Location;
            else
                return ninja4Location;
        }

        public static bool CheckGivenMoveIsValied() 
        {
            bool isTrue = false;
            int currentPillarID = GetCurrentSelectedNinjasPillarID();
            int movingPillarID = MovingPillarID;

            if (currentPillarID == 1)
            {
                if (movingPillarID == 3 || movingPillarID == 7 || movingPillarID == 11)
                {
                    isTrue = true;
                }
            }

            return isTrue;
        }


        //public static bool CheckNinjaMoveToCLickedPoint(Vector3 ninjaPosition, Vector3 clickedPosition)
        //{
        //    bool isValied = false;
        //    float ninja_x = ninjaPosition.x;
        //    float ninja_y = ninjaPosition.y;
        //    float mouseClick_x = clickedPosition.x;
        //    float mouseClick_y = clickedPosition.y;

        //    if (ninja_x + 0.3 > mouseClick_x && mouseClick_x > ninja_x - 0.3 && ninja_y + 0.3 > mouseClick_y && ninja_y - 0.3 < mouseClick_y)
        //    {
        //        isValied = true;
        //    }
        //    if (mouseClick_x + 0.3 > ninja_x && ninja_x > mouseClick_x - 0.3 && mouseClick_y + 0.3 > ninja_y && mouseClick_y - 0.3 < ninja_y)
        //    {
        //        isValied = true;
        //    }

        //    return isValied;
        //}
    }
}
