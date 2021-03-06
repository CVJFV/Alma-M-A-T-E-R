﻿// <auto-generated />
using System;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20190517164814_ModelFixes1")]
    partial class ModelFixes1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Apartment", b =>
                {
                    b.Property<int>("ApartmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<int?>("OfficeId");

                    b.Property<int>("Price");

                    b.Property<int>("RoomNumber");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Type");

                    b.HasKey("ApartmentID");

                    b.HasIndex("OfficeId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("API.CarRental", b =>
                {
                    b.Property<int>("CarRentalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CarIssueDate");

                    b.Property<string>("CarPickupAddress");

                    b.Property<string>("CarRentalCompany");

                    b.Property<string>("CarRentalUrl");

                    b.Property<DateTime>("CarReturnDate");

                    b.Property<int>("Price");

                    b.Property<int>("TripID");

                    b.HasKey("CarRentalID");

                    b.HasIndex("TripID");

                    b.ToTable("CarRentals");
                });

            modelBuilder.Entity("API.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.EmployeeToTrip", b =>
                {
                    b.Property<int>("EmployeeToTripID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID");

                    b.Property<string>("Status");

                    b.Property<int>("TripId");

                    b.Property<bool>("WasRead");

                    b.HasKey("EmployeeToTripID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TripId");

                    b.ToTable("EmployeeToTrips");
                });

            modelBuilder.Entity("API.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int>("EmployeeID");

                    b.Property<string>("name");

                    b.HasKey("EventID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("API.GasCompensation", b =>
                {
                    b.Property<int>("GasCompensationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID");

                    b.Property<int>("Price");

                    b.Property<int>("TripID");

                    b.HasKey("GasCompensationID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TripID");

                    b.ToTable("GasCompensations");
                });

            modelBuilder.Entity("API.Office", b =>
                {
                    b.Property<int>("OfficeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.HasKey("OfficeID");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("API.PlaneTicket", b =>
                {
                    b.Property<int>("PlaneTicketID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Airport");

                    b.Property<int>("EmployeeID");

                    b.Property<string>("FlightCompany");

                    b.Property<DateTime>("ForwardFlightDate");

                    b.Property<string>("PlaneTicketUrl");

                    b.Property<int>("Price");

                    b.Property<DateTime>("ReturnFlightDate");

                    b.Property<int>("TripID");

                    b.HasKey("PlaneTicketID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TripID");

                    b.ToTable("PlaneTickets");
                });

            modelBuilder.Entity("API.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentID");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<int>("EmployeeID");

                    b.Property<string>("ReservationUrl");

                    b.Property<int>("TripID");

                    b.HasKey("ReservationID");

                    b.HasIndex("ApartmentID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TripID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("API.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArrivalOfficeID");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int>("DepartureOfficeID");

                    b.Property<bool>("IsCarCompensationNeeded");

                    b.Property<bool>("IsCarRentalNeeded");

                    b.Property<bool>("IsPlaneNeeded");

                    b.Property<DateTime>("ReturnDate");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Status");

                    b.HasKey("TripID");

                    b.HasIndex("ArrivalOfficeID");

                    b.HasIndex("DepartureOfficeID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("API.Apartment", b =>
                {
                    b.HasOne("API.Office", "Office")
                        .WithMany("Apartaments")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("API.CarRental", b =>
                {
                    b.HasOne("API.Trip", "Trip")
                        .WithMany("CarRentals")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.EmployeeToTrip", b =>
                {
                    b.HasOne("API.Employee", "Employee")
                        .WithMany("EmployeeToTrip")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Trip", "Trip")
                        .WithMany("EmployeesToTrip")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Event", b =>
                {
                    b.HasOne("API.Employee", "Employee")
                        .WithMany("Events")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.GasCompensation", b =>
                {
                    b.HasOne("API.Employee", "Employee")
                        .WithMany("GasCompensations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Trip", "Trip")
                        .WithMany("GasCompensations")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.PlaneTicket", b =>
                {
                    b.HasOne("API.Employee", "Employee")
                        .WithMany("PlaneTickets")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Trip", "Trip")
                        .WithMany("PlaneTickets")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Reservation", b =>
                {
                    b.HasOne("API.Apartment", "Apartment")
                        .WithMany("Reservations")
                        .HasForeignKey("ApartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Employee", "Employee")
                        .WithMany("Reservations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Trip", "Trip")
                        .WithMany("Reservations")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Trip", b =>
                {
                    b.HasOne("API.Office", "ArrivalOffice")
                        .WithMany()
                        .HasForeignKey("ArrivalOfficeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Office", "DepartureOffice")
                        .WithMany()
                        .HasForeignKey("DepartureOfficeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
