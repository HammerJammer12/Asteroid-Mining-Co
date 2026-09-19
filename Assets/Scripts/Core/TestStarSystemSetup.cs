public static class TestStarSystemSetup
{
    public static StarSystem BuildSol(Item oreItem)
    {
        var system = new StarSystem("sol", "Sol");

        var star = new Star("sol-star", "Sol", system, 50000f);
        system.SetStar(star);

        var earthOrbit = new Orbit(apoapsis: 1000f, periapsis: 950f,
            argumentOfPeriapsis: 0f, meanAnomalyAtEpoch: 0f, parent: star);
        var earth = new Planet("earth", "Earth", system, earthOrbit, 400f);
        system.AddLocation(earth);

        var moonOrbit = new Orbit(apoapsis: 20f, periapsis: 18f,
            argumentOfPeriapsis: 0f, meanAnomalyAtEpoch: 0f, parent: earth);
        var luna = new Moon("luna", "Luna", system, earth, moonOrbit);
        system.AddLocation(luna);

        var beltOrbit = new Orbit(apoapsis: 1500f, periapsis: 1400f,
            argumentOfPeriapsis: 2f, meanAnomalyAtEpoch: 1.5f, parent: star);

        var belt = new AsteroidField("belt-1", "Outer Belt", system, beltOrbit);

        var deposit = new AsteroidDeposit(oreItem, 2000);
        belt.Deposits.Add(deposit);
        system.AddLocation(belt);

        return system;
    }
}