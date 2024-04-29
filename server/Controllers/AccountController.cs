namespace Final.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, VaultsService vaultsService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut]
  [Authorize]
  public async Task<ActionResult<Account>> Edit([FromBody] Account account)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      account.Email = userInfo.Email;
      Account updatedAccount = _accountService.Edit(account, account.Email);
      return Ok(updatedAccount);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpGet("vaults")]
  public async Task<ActionResult<List<Vault>>> GetMyVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByProfile(userInfo.Id, true);
      return vaults;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
