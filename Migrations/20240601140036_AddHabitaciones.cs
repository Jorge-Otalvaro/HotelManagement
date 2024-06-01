using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Habitaciones",
                newName: "TipoHabitacion");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Habitaciones",
                newName: "NumeroHabitacion");

            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "TipoHabitacion",
                table: "Habitaciones",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "NumeroHabitacion",
                table: "Habitaciones",
                newName: "Numero");
        }
    }
}
