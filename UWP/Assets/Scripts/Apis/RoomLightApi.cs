using RoomLight;

public class RoomLightApi : NatureRemoApi {

    // Singltonパターン
    private static RoomLightApi m_Instance;

    public static RoomLightApi instance {
        get {
            if( m_Instance == null ) m_Instance = new RoomLightApi();
            return m_Instance;
        }
    }
}
