using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CuallimexManagement.Entities
{
    public class PhysicalInspection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // Condiciones del Equipo
        [BsonElement("EquipmentConditions")]
        public string EquipmentConditions { get; set; } // Condiciones del equipo (BUENAS, REGULAR, MALAS, GOLPEADO, SUCIO)

        [BsonElement("EquipmentComments")]
        public string EquipmentComments { get; set; } // Comentarios sobre las condiciones del equipo

        // Condición del Motor
        [BsonElement("MotorCondition")]
        public string MotorCondition { get; set; } // Condición del motor (BUENAS, REGULAR, MALAS, GOLPEADO, SUCIO)

        [BsonElement("MotorComments")]
        public string MotorComments { get; set; } // Comentarios sobre la condición del motor

        // Cubierta de Motor
        [BsonElement("MotorCoverCondition")]
        public string MotorCoverCondition { get; set; } // Condición de la cubierta del motor (BUENAS, REGULAR, MALAS, GOLPEADO, SUCIO)

        [BsonElement("MotorCoverComments")]
        public string MotorCoverComments { get; set; } // Comentarios sobre la cubierta del motor

        // Ventilador del Motor
        [BsonElement("MotorFanCondition")]
        public string MotorFanCondition { get; set; } // Condición del ventilador del motor (BUENAS, REGULAR, MALAS, GOLPEADO, SUCIO)

        [BsonElement("MotorFanComments")]
        public string MotorFanComments { get; set; } // Comentarios sobre el ventilador del motor

        // Se puede realizar prueba
        [BsonElement("TestCanBePerformed")]
        public bool TestCanBePerformed { get; set; } // Se puede realizar la prueba (SI, NO)

        [BsonElement("TestComments")]
        public string TestComments { get; set; } // Comentario sobre si se puede realizar la prueba

        // Es necesario desarmar el equipo
        [BsonElement("DisassemblyRequired")]
        public bool DisassemblyRequired { get; set; } // Es necesario desarmar el equipo (SI, NO)

        // Motor Data
        [BsonElement("Brand")]
        public string Brand { get; set; } // Marca del motor

        [BsonElement("Model")]
        public string Model { get; set; } // Modelo del 

        [BsonElement("Year")]
        public int Year { get; set; } // Año del 

        [BsonElement("SerialNumber")]
        public string SerialNumber { get; set; } // Número de serie del 

        [BsonElement("Power")]
        public string Power { get; set; } // Potencia del 

        [BsonElement("RPM")]
        public int RPM { get; set; } // RPM del 
    }
}
