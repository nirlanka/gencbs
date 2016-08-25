using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencbs.Resources;

namespace gencbs
{
    class Test_data
    {
        //testing data
        //resource types
        //doctors
        ResourceType doc_genral_physician = new ResourceType("doc_general_physician", 0); //A doctor who offers treatment for mild conditions.
        ResourceType doc_anesthesiologist = new ResourceType("doc_anesthesiologist", 0); //Administers and studies anesthesia for surgical procedures
        ResourceType doc_general_surgeons = new ResourceType("doc_general_surgeons", 0); //Performs surgeries that are related to different areas of medicine
        ResourceType doc_pediatric_cardiologist = new ResourceType("doc_pediatric_cardiologist", 0); //Treats and diagnoses heart complication in infants.
        ResourceType doc_urologist = new ResourceType("doc_urologist", 0); //Treats, diagnoses and studies health issues related to the urinary tract, kidney and urinary system
        ResourceType doc_andrologist = new ResourceType("doc_andrologist", 0); //Treats and diagnoses medical issues with the male reproductive system
        ResourceType doc_gynecologist = new ResourceType("doc_gynecologist", 0); //Treats and diagnoses conditions in the reproductive system of females
        ResourceType doc_radiation_oncologist = new ResourceType("doc_andrologist", 0); //Specializes in treating cancer using radiation
        ResourceType doc_surgical_oncologist = new ResourceType("doc_surgical_oncologist", 0); //Deals with administering surgical procedures to treat cancer. Uses biopsy to diagnose cancer. Removes tumors and cancerous tissues
        ResourceType doc_neurosurgeon = new ResourceType("doc_neurosurgeon", 0); //Specializes in the treatment of diseases affecting the nervous system and the brain


        //nurses
        ResourceType nurse_general = new ResourceType("nurse_general", 0);
        ResourceType nurse_perioperative = new ResourceType("nurse_perioperative", 0); //operating room nurses
        ResourceType nurse_anesthetists = new ResourceType("nurse_anesthetists", 0);
        ResourceType nurse_midwife = new ResourceType("nurse_midwife", 0); //specialized in childbirth
        ResourceType nurse_oncology = new ResourceType("nurse_oncology", 0); //specialized in cancer treatments

        //allied health proffesionals
        ResourceType ahs_surgical_technologist = new ResourceType("ahs_surgical_technologist", 0); //part of a surgical team
        ResourceType ahs_radiotherapist = new ResourceType("ahs_radiotherapist", 0); //works in radiation therapy
        ResourceType ahs_radiation_scientist = new ResourceType("ahs_radiation_scientist", 0);

        //other hospital staff.
        //todo: add other hospital staff here


        //rosters
        //--todo: add set of different rosteres here


        //---RESOURCES--
        //DOCTORS
        //todo: add doctors here


        //NURSES
        //todo: add nurses here
    }
}
