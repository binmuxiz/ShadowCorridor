using UnityEngine;

//TODO 이거 먼지 이해하기
// [AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public Camera mainCam;
    public float rayDistance = 3f;
    public AudioSource audioSource;
    
    private int _layerMask;
    
    // Header : Inspector창에서 변수 그룹의 제목을 정할 수 있다.
    // SerializedField : 멤버변수가 private이라도 Inspector 창에서 편집 가능하도록
    // Tooltip : Inspector 창에서 변수에 마우스를 올려놓으면 설명 텍스트 제공 
    
    [Header("Prefab Refrences")]
    // 총알 프리팹
    public GameObject bulletPrefab;
    // 탄피 프리팹
    public GameObject casingPrefab;
    // 총구 섬광 (발사 효과) 프리팹 
    public GameObject muzzleFlashPrefab;

    [Header("Location References")]
    // 총 애니메이션 담당하는 Animator 컴포넌트
    [SerializeField] private Animator gunAnimator;
    // 총알이 발사되는 위치를 나타냄 (보통 총구의 위치)
    [SerializeField] private Transform barrelLocation;
    // 탄피가 배출되는 위치 
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    // 생성된 탄피나 총구 섬광 효과를 몇 초 뒤에 파괴할지
    [Tooltip("Specify time to destory the casing object")] 
    [SerializeField] private float destroyTimer = 2f;
    // 발사된 총알의 속도 
    [Tooltip("Bullet Speed")] 
    [SerializeField] private float shotPower = 500f;
    // 탄피 배출 시 탄피에 적용되는 힘의 크기 
    [Tooltip("Casing Ejection Speed")] 
    [SerializeField] private float ejectPower = 150f;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
        
        // todo 이거 이해하기 
        _layerMask = 1 << LayerMask.NameToLayer("Zombie");
    }

    void Update()
    {
        //If you want a different input, change it here
        if (Input.GetMouseButtonDown(0))
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
            
            // TODO 총 사운드
            audioSource.Play();
            
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, _layerMask))
            {
                Debug.Log("좀비 hit");
                //todo 좀비 너무 빠름 

                Ghoul ghoul = hit.transform.gameObject.GetComponent<Ghoul>();
                ghoul.TakeDamage();
            }
            
            // 인벤토리에 총 사용 -> 개수 감소 
            // int currentIdx = Inventory.Instance.CurrentIdx;
            // Inventory.Instance.ControlItemCount(currentIdx);
            // Handgun.Instance.Cancel();                         
        }
    }

    /**
     * Shoot(), CasingRelease()는 애니메이션 이벤트를 통해 호출된다.
     * 애니메이션 이벤트 : 애니메이션 클립의 특정 프레임에 메서드를 호출할 수 있는 기능 - 애니메이션 이벤트에 의해 메소드가 호출된다. 
     * 
     */
    //This function creates the bullet behavior
    // 총알 발사와 관련된 모든 행동을 수행하는 메소드 
    void Shoot()
    {
        if (muzzleFlashPrefab && bulletPrefab) // null 체크
        {
            // 섬광 효과 인스턴스화 
            GameObject tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            // Create a bullet and add force on it in direction of the barrel
            // 총알 프리팹을 인스턴스화
            // 총알을 현재 총구의 position, rotation에 생성 
            // 총알에 shotPower 크기의 힘을 Rigidbody를 통해 적용하여 발사 
            GameObject tempBullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            tempBullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            
            Destroy(tempFlash, destroyTimer);
            Destroy(tempBullet, destroyTimer);
        }
    }

    // This function creates a casing at the ejection slot
    // 탄피 배출과 관련된 모든 행동을 수행하는 메서드 
    void CasingRelease()
     {
    // TODO 코드 이해하기 8/14 할일 
         //Cancels function if ejection slot hasn't been set or there's no casing
         if (!casingExitLocation || !casingPrefab)
         { return; }
    
         //Create the casing
         GameObject tempCasing;
         tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
         //Add force on casing to push it out
         tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
         //Add torque to make casing spin in random direction
         tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
    
         //Destroy casing after X seconds
         Destroy(tempCasing, destroyTimer);
     }
}
