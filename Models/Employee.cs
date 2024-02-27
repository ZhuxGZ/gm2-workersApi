using System;
namespace workersApi.Models
{
	public class Employee
	{
        /*
            Este es el Id en la base de datos? Si es asi, no se utiliza en los modelos/entidades, ya que el id es auto generado.
            Cuando creas un script para insertar la tabla en la base de datos, ahi es donde creas el Id 
            Ejemplo: (aclaro que esto es PosgreSQL)
            CREATE TABLE IF NOT EXISTS "core-kyc".kyc_application
            (
                id                           UUID NOT NULL
                    CONSTRAINT kyc_application_pk
                        PRIMARY KEY,
                current_verification_step_id UUID,
                customer_id                  VARCHAR NOT NULL,
                input_params                 jsonb default '{}'::jsonb,
                status                       INTEGER NOT NULL,
                next_action                  INTEGER,
                country                      VARCHAR,
                created_on                   timestamp with time zone NOT NULL,
                modified_on                  timestamp with time zone
            );
        */ 
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Area { get; set; } = String.Empty;
        public string Seniority { get; set; } = String.Empty;
        public int Wage { get; set; }
        public string Address { get; set; } = String.Empty;
        public int ZipCode { get; set; }
        public string? Project { get; set; } = String.Empty;
        public DateTime Joined { get; set; }
    }

    /*
        Nunca debemos poner mas de una clase dentro del mismo archivo! (ya se que en los videos tutoriales aparece asi jeje)
        Tambien creo que esta clase es un DTO! (Data transfer object) ¿Te acordas para que se utiliza? ¿Sabes por que lo necesitas?
    */
    public class AddEmployee
    {
        public string Name { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Area { get; set; } = String.Empty;
        public string Seniority { get; set; } = String.Empty;
        public int Wage { get; set; }
        public string Address { get; set; } = String.Empty;
        public int ZipCode { get; set; }
        public string? Project { get; set; } = String.Empty;
    }
}
