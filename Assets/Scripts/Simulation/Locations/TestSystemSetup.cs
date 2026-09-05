/// <summary>
/// For testing/development only
/// </summary>
public static class TestSystemSetup
{
    public static StarSystem BuildSolarSystem()
    {
        var system = new StarSystem("sol", "sol");
        var star = new Star("sol-star", "Sol", system, 50000f);
        system.SetStar(star);

        var earthOrbit = new Orbit(
            1000f,
            950f,
            0f,
            0f,
            star
        );
        var earth = new Planet(
            "earth",
            "Earth",
            system,
            earthOrbit,
            400f
        );
        system.AddLocation(earth);

        var moonOrbit = new Orbit(
            20f,
            18f,
            0f,
            0f,
            earth
        );
        var luna = new Moon(
            "luna",
            "Lunda",
            system,
            earth,
            moonOrbit
        );
        system.AddLocation(luna);

        var beltOrbit = new Orbit(
            1500f,
            1400f,
            2f,
            1.5f,
            star
        );
        var belt = new AsteroidField(
            "belt-1",
            "Outer Belt",
            system,
            beltOrbit
        );
        system.AddLocation(belt);

        return system;
    }
}
